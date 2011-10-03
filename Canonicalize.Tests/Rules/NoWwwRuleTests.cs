using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class NoWwwRuleTests
    {
        [TestCase("http://www.example.com", "http://example.com", TestName = "Removes www when present")]
        [TestCase("http://example.com", "http://example.com", TestName = "Leaves URL without www untouched")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IRule rule = new NoWwwRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
