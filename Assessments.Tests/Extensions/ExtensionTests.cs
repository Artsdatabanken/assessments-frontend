using Assessments.Shared.Helpers;
using FluentAssertions;

namespace Assessments.Tests.Extensions
{
    public class ExtensionTests
    {
        [Fact]
        public void StripHtmlExtensionShouldRemoveHtml()
        {
            "<p>Lorem ipsum</p>".StripHtml().Should().Be("Lorem ipsum");
        }
        
        [Fact]
        public void RemoveUnwantedHtmlTagsExtensionShouldRemoveUnwantedHtmlTags()
        {
            "<p>Lorem ipsum</p><div>Lorem ipsum</div>".StripUnwantedHtml().Should().Be("<p>Lorem ipsum</p>Lorem ipsum");
        }
    }
}