using System.ComponentModel;
using System.Reflection;
using System.Text.Encodings.Web;
using Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages;

public static class HtmlShowTable
{
    public static IHtmlContent ShowTable<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        IEnumerable<TModel> items, string sortOrder, string searchStr, int pageNr) where TModel : IEntity
    {
        var table = new TagBuilder("table");
        table.AddCssClass("table");

        var properties = getProperties(typeof(TModel));

        var thead = h.createHead(properties, sortOrder, searchStr, pageNr);
        table.InnerHtml.AppendHtml(thead);

        var tbody = h.createBody(properties, items);
        table.InnerHtml.AppendHtml(tbody);

        var writer = new StringWriter();
        table.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());
    }

    private static TagBuilder createBody<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        PropertyInfo[] properties, IEnumerable<TModel> items) where TModel : IEntity
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

    private static TagBuilder createHead<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        PropertyInfo[] properties, string sortOrder, string searchStr, int pageNr)
    {
        var thead = new TagBuilder("thead");
        var tr = new TagBuilder("tr");
        foreach (var p in properties) h.addColumn(tr, p, sortOrder, searchStr, pageNr);
        h.addColumn(tr, string.Empty);
        thead.InnerHtml.AppendHtml(tr);
        return thead;
    }
    private static string newName(PropertyInfo p, string sortOrder)
    {
        var name = p.Name;
        var displayName = p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? name;
        if (string.IsNullOrEmpty(sortOrder)) return displayName;
        if (!sortOrder.StartsWith(name)) return displayName;
        if (sortOrder.EndsWith("_desc")) return $"{displayName} ↓";
        return $"{displayName} ↑";
    }
    private static void addColumn<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        TagBuilder tr, PropertyInfo p, string sortOrder, string searchStr, int pageNr, string tag = "td")
    {
        var n = newName(p, sortOrder);
        sortOrder = newSortOrder(p.Name, sortOrder);
        var th = new TagBuilder(tag);
        var v = h.ActionLink(n, "Index", new { SortOrder = sortOrder, SearchString = searchStr, PageNumber = pageNr });
        th.InnerHtml.AppendHtml(v);
        tr.InnerHtml.AppendHtml(th);
    }

    private static string newSortOrder(string name, string sortOrder)
    {
        if (name is null) return string.Empty;
        if(sortOrder is null ) return name;
        if (!sortOrder.StartsWith(name)) return name;
        if(sortOrder.EndsWith("_desc")) return name;
        return name + "_desc";
    }

    private static void addColumn<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, 
        TagBuilder tr, string value, string tag = "td")
    {
        var th = new TagBuilder(tag);
        var v = h.Raw(value);
        th.InnerHtml.AppendHtml(v);
        tr.InnerHtml.AppendHtml(th);
    }

    private static PropertyInfo[] getProperties(Type t) => t?.GetProperties()?.Where(x => x.Name != "Id")?.ToArray() ?? [];
}