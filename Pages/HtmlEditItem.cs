using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages;
public static class HtmlEditItem
{
    public static IHtmlContent EditItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e)
    {
        var label = h.LabelFor(e, new { @class = "control-label" } );
        var editor = h.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } } );
        var validation = h.ValidationMessageFor(e, string.Empty, new { @class = "text-danger" });

        var div = new TagBuilder("div");
        div.AddCssClass("form-group");

        div.InnerHtml.AppendHtml(label);
        div.InnerHtml.AppendHtml(editor);
        div.InnerHtml.AppendHtml(validation);

        var writer = new StringWriter();
        div.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());
    }
}