using System;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    class PatternTests
    {
        [TestCase("http://example.com/foo", "http://example.com/bar", TestName = "Complete match")]
        [TestCase("http://example.com/foo/more", "http://example.com/bar/more", TestName = "Partial match")]
        [TestCase("http://example.com/fuu/more", "http://example.com/fuu/more", TestName = "No match")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IUrlStrategy strategy = new Pattern(@"^/foo\b", "/bar");
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
