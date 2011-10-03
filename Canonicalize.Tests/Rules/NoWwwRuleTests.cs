using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class NoWwwRuleTests
    {
        [Test]
        public void removes_www_when_present()
        {
            var inputUrl = new Uri("http://www.example.com");
            var expectedUrl = new Uri("http://example.com");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new NoWwwRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void does_not_alter_url_with_www()
        {
            var inputUrl = new Uri("http://example.com");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new NoWwwRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(inputUrl));
        }
    }
}
