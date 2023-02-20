using Assessments.Shared.Helpers;
using FluentAssertions;

namespace Assessments.Tests.Extensions
{
    public class StripHtmlExtensionsTests
    {
        [Fact]
        public void StripHtmlExtensionShouldRemoveHtmlTags()
        {
            @"<p style=""font-size: 28px"">Lorem ipsum</p>".StripHtml().Should().Be("Lorem ipsum");
        }
        
        [Fact]
        public void StripUnwantedHtmlTagsExtensionShouldRemoveUnwantedHtmlTags()
        {
            @"<p style=""font-size: 28px"">Lorem ipsum</p><div>Lorem ipsum</div>".StripUnwantedHtml().Should().Be("<p>Lorem ipsum</p>Lorem ipsum");
        }

        [Fact]
        public void StripUnwantedHtmlTagsExtensionShouldRemoveUnwantedHtmlTagsButKeepLinks()
        {
            @"<a style=""font-size: 28px"" href=""https://artsdatabanken.no"">artsdatabanken</a>".StripUnwantedHtml().Should().Be(@"<a href=""https://artsdatabanken.no"">artsdatabanken</a>");
        }

        [Fact]
        public void StripHtmlExtensionShouldReplaceNonBreakingSpace()
        {
            @"<p style=""font-size: 28px"">Lorem&nbsp;ipsum</p>".StripHtml().Should().Be("Lorem ipsum");
        }

        [Fact]
        public void StripUnwantedHtmlExtensionShouldReplaceNonBreakingSpace()
        {
            @"<p style=""font-size: 28px"">Lorem&nbsp;ipsum</p>".StripUnwantedHtml().Should().Be("<p>Lorem ipsum</p>");
        }
    }
}