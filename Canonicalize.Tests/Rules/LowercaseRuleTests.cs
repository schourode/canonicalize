using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    class LowercaseRuleTests
    {
        [Test]
        public void url_unchanged_if_already_lowercase()
        {
            var rule = new LowercaseRule();
            var inputUrl = new Uri("http://example.com/foobar");

            var outputUrl = rule.Canonicalize(inputUrl);

            Assert.That(inputUrl, Is.EqualTo(outputUrl));
        }

        [Test]
        public void url_with_uppercase_chars_gets_lowercased()
        {
            var rule = new LowercaseRule();
            var inputUrl = new Uri("http://example.com/FOObar");
            var expectedUrl = new Uri("http://example.com/foobar");

            var outputUrl = rule.Canonicalize(inputUrl);

            Assert.That(expectedUrl, Is.EqualTo(outputUrl));
        }

        [Test]
        public void query_is_not_affected_by_case_change()
        {
            var rule = new LowercaseRule();
            var inputUrl = new Uri("http://example.com/FOObar?FOO=1&bar=2");
            var expectedUrl = new Uri("http://example.com/foobar?FOO=1&bar=2");

            var outputUrl = rule.Canonicalize(inputUrl);

            Assert.That(expectedUrl, Is.EqualTo(outputUrl));
        }
    }
}
