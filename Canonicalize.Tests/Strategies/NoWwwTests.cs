using System;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    public class NoWwwTests
    {
        [TestCase("http://www.example.com", "http://example.com", TestName = "Removes www when present")]
        [TestCase("http://example.com", "http://example.com", TestName = "Leaves URL without www untouched")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IUrlStrategy strategy = new NoWww();
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
