using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Encodings.Web;

namespace Pages;
public static class HtmlSelectItem
{
    public static IHtmlContent SelectItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e, SelectList selectList)
    {
        var label = h.LabelFor(e, new { @class = "control-label" });
        var ed = h.DropDownListFor(e, addDescr<TModel>(selectList), new { @class = "form-control" });
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

    private static IEnumerable<SelectListItem> addDescr<TModel>(SelectList sl)
    {
        var l = sl.ToList();
        l.Insert(0, new SelectListItem { Text = $"--  {toDescr(typeof(TModel))} --", Value = "" });
        return l;
    }

    internal static object toDescr(Type type)
    {
        var a = type?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
        return a?.Description ?? type?.Name ?? string.Empty;
    }
}
