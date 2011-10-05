using System;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    public class NoTrailingSlashTests
    {
        [TestCase("http://example.com/foobar/", "http://example.com/foobar", TestName = "Removes slash when present")]
        [TestCase("http://example.com/foobar", "http://example.com/foobar", TestName = "Leaves URL without slash untouched")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IUrlStrategy strategy = new NoTrailingSlash();
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
