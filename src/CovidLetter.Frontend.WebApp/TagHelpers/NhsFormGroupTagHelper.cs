using System.Text.Encodings.Web;
using CovidLetter.Frontend.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CovidLetter.Frontend.WebApp.TagHelpers
{
    public class NhsFormGroupTagHelper : TagHelper
    {
        [HtmlAttributeName(Attribute.NhsValidationFor)]
        public ModelExpression? For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext? ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.AddClass("nhsuk-form-group", HtmlEncoder.Default);
            output.TagName = "div";

            if (ViewContext != null && (For == null && !ViewContext.ViewData.ModelState.IsValid
                || For != null && ViewContext.ViewData.ModelState.HasError(For.Name)))
            {
                output.AddClass("nhsuk-form-group--error", HtmlEncoder.Default);
            }
        }
    }
}