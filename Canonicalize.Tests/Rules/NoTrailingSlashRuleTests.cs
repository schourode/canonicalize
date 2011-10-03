using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class NoTrailingSlashRuleTests
    {
        [TestCase("http://example.com/foobar/", "http://example.com/foobar", TestName = "Removes slash when present")]
        [TestCase("http://example.com/foobar", "http://example.com/foobar", TestName = "Leaves URL without slash untouched")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IRule rule = new NoTrailingSlashRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
