using System.Reflection;
using System.Text.Encodings.Web;
using Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages;

public static class HtmlShowTable
{
    public static IHtmlContent ShowTable<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        IEnumerable<TModel> items) where TModel : EntityData
    {
        var table = new TagBuilder("table");
        table.AddCssClass("table");

        var properties = getProperties(typeof(TModel));

        var thead = h.createHead(properties);
        table.InnerHtml.AppendHtml(thead);

        var tbody = h.createBody(properties, items);
        table.InnerHtml.AppendHtml(tbody);

        var writer = new StringWriter();
        table.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());
    }

    private static TagBuilder createBody<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        PropertyInfo[] properties, IEnumerable<TModel> items) where TModel : EntityData
    {
        var tbody = new TagBuilder("body");
        foreach (var i in items)
        {
            var tr = new TagBuilder("tr");
            TagBuilder td;
            foreach (var p in properties)
            {
                td = new TagBuilder("td");
                var v = p?.GetValue(i)?.ToString()?? string.Empty;
                var value = h.Raw(v);
                td.InnerHtml.AppendHtml(value);
                tr.InnerHtml.AppendHtml(td);
            }
            var id = i?.Id.ToString()?? string.Empty;
            td = new TagBuilder("td");
            h.addLink("Edit", id, td);
            h.addLink("Details", id, td);
            h.addLink("Delete", id, td, true);
            tr.InnerHtml.AppendHtml(td);
            tbody.InnerHtml.AppendHtml(tr);
        }
        return tbody;
    }
    private static void addLink<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, string action, string id, TagBuilder td, bool isLast = false)
    {
        var link = h.ActionLink(action, action, new { Id = id });
        td.InnerHtml.AppendHtml(link);
        if (isLast) return;
        td.InnerHtml.AppendHtml(new HtmlString(" | "));
    }

    private static TagBuilder createHead<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, PropertyInfo[] properties)
    {
        var thead = new TagBuilder("thead");
        var tr = new TagBuilder("tr");
        foreach (var p in properties) h.addColumn(tr, p.Name);
        h.addColumn(tr, string.Empty);
        thead.InnerHtml.AppendHtml(tr);
        return thead;
    }
    private static void addColumn<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, TagBuilder tr, string value, string tag = "th")
    {
        var th = new TagBuilder(tag);
        var v = h.Raw(value);
        th.InnerHtml.AppendHtml(v);
        tr.InnerHtml.AppendHtml(th);
    }

    private static PropertyInfo[] getProperties(Type t) => t?.GetProperties()?.Where(x => x.Name != "Id")?.ToArray() ?? [];
}