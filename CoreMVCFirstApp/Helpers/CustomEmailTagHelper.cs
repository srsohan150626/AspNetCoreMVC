using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CoreMVCFirstApp.Helpers
{
    public class CustomEmailTagHelper: TagHelper
    {
        public string Myemail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{Myemail}");
            output.Content.SetContent("my-email");
        }
    }
}
