﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MoviesApp.TagHelpers
{
    [HtmlTargetElement("last-action-message")]
    public class LastActionMessageTagHelper : TagHelper
    {
        [ViewContext()]
        [HtmlAttributeNotBound()]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext.TempData.ContainsKey("LastActionMessage"))
            {
                /*
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    <span>@TempData["LastActionMessage"]</span>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                 
                 */
                // first build a child button:
                var childBtn = new TagBuilder("button");
                childBtn.Attributes.Add("class", "btn-close");
                childBtn.Attributes.Add("data-bs-dismiss", "alert");
                childBtn.Attributes.Add("aria-label", "close");

                // And a child span:
                var childSpan = new TagBuilder("span");
                childSpan.InnerHtml.AppendHtml(ViewContext.TempData["LastActionMessage"].ToString());

                // set ouptput content to be a div:
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                output.Attributes.Add("role", "alert");

                // append btn & span to div:
                output.Content.AppendHtml(childSpan);
                output.Content.AppendHtml(childBtn);
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
