using System;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    class LowercaseTests
    {
        [TestCase("http://example.com/FOObar", "http://example.com/foobar", TestName = "Converts path to lower case")]
        [TestCase("http://example.com/foobar", "http://example.com/foobar", TestName = "Leaves already lower caed path untouched")]
        [TestCase("http://example.com/FOObar?FOO=bar&bar=FOO", "http://example.com/foobar?FOO=bar&bar=FOO", TestName = "Query string unaffected by case change")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IUrlStrategy strategy = new Lowercase();
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
