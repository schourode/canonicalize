using System;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    class HostStrategyTests
    {
        [TestCase("http://example.com", "http://example.net", TestName = "Canonicalizes host name")]
        [TestCase("http://example.net", "http://example.net", TestName = "No change if already canonical host name")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IUrlStrategy strategy = new HostStrategy("example.net");
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
