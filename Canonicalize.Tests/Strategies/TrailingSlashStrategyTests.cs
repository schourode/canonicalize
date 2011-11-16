using System;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    public class TrailingSlashStrategyTests
    {
        [TestCase("http://example.com/foobar", "http://example.com/foobar/", TestName = "Appends slash when not present")]
        [TestCase("http://example.com/foobar/", "http://example.com/foobar/", TestName = "Does not append duplicate slash")]
        [TestCase("http://example.com/foobar.html", "http://example.com/foobar.html", TestName = "Does not append slash after extension")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IUrlStrategy strategy = new TrailingSlashStrategy();
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
