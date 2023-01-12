using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lesson35MVC.Helpers;
// mvc only, in blazor - components
// <p>*</p>
[HtmlTargetElement("p")]
public class ParagraphHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childContent = (await output.GetChildContentAsync()).GetContent();
        output.AddClass("h1", HtmlEncoder.Default);
        output.Content.SetContent($"{childContent} tag processed");
    }
}