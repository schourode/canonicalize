using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class WwwRuleTests
    {
        [TestCase("http://example.com", "http://www.example.com", TestName = "Adds www when not present")]
        [TestCase("http://www.example.com", "http://www.example.com", TestName = "Does not add duplicate www")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IRule rule = new WwwRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
