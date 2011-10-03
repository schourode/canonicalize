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
            var inputUrl = new Uri("http://example.com/foobar");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new LowercaseRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(inputUrl));
        }

        [Test]
        public void url_with_uppercase_chars_gets_lowercased()
        {
            var inputUrl = new Uri("http://example.com/FOObar");
            var expectedUrl = new Uri("http://example.com/foobar");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new LowercaseRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void query_is_not_affected_by_case_change()
        {
            var inputUrl = new Uri("http://example.com/FOObar?FOO=1&bar=2");
            var expectedUrl = new Uri("http://example.com/foobar?FOO=1&bar=2");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new LowercaseRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(expectedUrl));
        }
    }
}
