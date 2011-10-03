using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    class LowercaseRuleTests
    {
        [TestCase("http://example.com/FOObar", "http://example.com/foobar", TestName = "Converts path to lower case")]
        [TestCase("http://example.com/foobar", "http://example.com/foobar", TestName = "Leaves already lower caed path untouched")]
        [TestCase("http://example.com/FOObar?FOO=bar&bar=FOO", "http://example.com/foobar?FOO=bar&bar=FOO", TestName = "Query string unaffected by case change")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            IRule rule = new LowercaseRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
