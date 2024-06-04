using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Aids;

namespace Pages;
public static class HtmlSelectItem
{
    public static IHtmlContent SelectItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e, SelectList selectList)
    {
        var label = h.LabelFor(e, new { @class = "control-label" });
        var displayName = h.DisplayNameFor(e);
        var ed = h.DropDownListFor(e, addDescr(selectList, displayName), new { @class = "form-control" });
        var validation = h.ValidationMessageFor(e, string.Empty, new { @class = "text-danger" });

        var div = new TagBuilder("div");
        div.AddCssClass("form-group");
        div.InnerHtml.AppendHtml(label);
        div.InnerHtml.AppendHtml(ed);
        div.InnerHtml.AppendHtml(validation);

        var w = new StringWriter();
        div.WriteTo(w, HtmlEncoder.Default);

        return new HtmlString(w.ToString());
    }
    public static IHtmlContent SelectItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e, string controller)
    {
        var label = h.LabelFor(e, new { @class = "control-label" });
        //var displayName = h.DisplayNameFor(e);
        var n = h.NameFor(e);
        var v = h.ValueFor(e);
        var ed = new HtmlString($"<select name=\"{n}\" class=\"selectItems2 form-control\" data-controller=\"{controller}\" data-id=\"{v}\"></select>");
        var validation = h.ValidationMessageFor(e, string.Empty, new { @class = "text-danger" });

        var div = new TagBuilder("div");
        div.AddCssClass("form-group");
        div.InnerHtml.AppendHtml(label);
        div.InnerHtml.AppendHtml(ed);
        div.InnerHtml.AppendHtml(validation);

        var w = new StringWriter();
        div.WriteTo(w, HtmlEncoder.Default);

        return new HtmlString(w.ToString());
    }

    private static IEnumerable<SelectListItem> addDescr(SelectList sl, string displayName)
    {
        var l = sl?.ToList() ?? [];
        l.Insert(0, new SelectListItem { Text = $"-- {Constants.Select} {displayName} --", Value = "" });
        return l;
    }

    //internal static object toDescr(Type type)
    //{
    //    var a = type?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
    //    return a?.Description ?? type?.Name ?? string.Empty;
    //}
}
