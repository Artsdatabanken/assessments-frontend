﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Assessments.Frontend.Web.Infrastructure
{
    [HtmlTargetElement("img", Attributes = "species-group-name")]
    public class SpeciesGroupImageSrcTagHelper : TagHelper
    {
        public string SpeciesGroupName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // NOTE: supress output if not "found"?

            if (SpeciesGroupName == "Amfibier, reptiler")
            { 
                output.Attributes.SetAttribute("src", $"/images/icons/Amfibier.svg"); 
            }
            else
            {
                output.Attributes.SetAttribute("src", $"/images/icons/{SpeciesGroupName}.svg");
            }

            base.Process(context, output);
        }
    }
}