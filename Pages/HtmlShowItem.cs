using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages;

public static class HtmlShowItem
{
    public static IHtmlContent ShowItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e)
    {
        var label = h.DisplayNameFor(e);
        var validation = h.DisplayFor(e);

        var dt = new TagBuilder("dt");
        dt.AddCssClass("col-sm-2");
        dt.InnerHtml.AppendHtml(label);

        var dd = new TagBuilder("dd");
        dd.AddCssClass("col-sm-10");
        dd.InnerHtml.AppendHtml(validation);

        var writer = new StringWriter();
        dt.WriteTo(writer, HtmlEncoder.Default);
        dd.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());
    }
}
