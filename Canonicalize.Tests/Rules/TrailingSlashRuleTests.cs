using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class TrailingSlashRuleTests
    {
        [TestCase("http://example.com/foobar", "http://example.com/foobar/", TestName = "Appends slash when not present")]
        [TestCase("http://example.com/foobar/", "http://example.com/foobar/", TestName = "Does not append duplicate slash")]
        [TestCase("http://example.com/foobar.html", "http://example.com/foobar.html", TestName = "Does not append slash after extension")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IRule rule = new TrailingSlashRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
