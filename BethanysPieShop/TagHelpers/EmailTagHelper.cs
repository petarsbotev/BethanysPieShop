using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShop.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string? EmailAddress { get; set; }
        public string? EmailText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(EmailAddress))
            {
                output.SuppressOutput();
                return;
            }
            var emailLink = $"mailto:{EmailAddress}";
            var linkText = string.IsNullOrEmpty(EmailText) ? EmailAddress : EmailText;
            output.TagName = "a";
            output.Attributes.SetAttribute("href", emailLink);
            output.Content.SetContent(linkText);
        }
    }
}
