using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class WwwRuleTests
    {
        [Test]
        public void adds_www_when_not_present()
        {
            var inputUrl = new Uri("http://example.com");
            var expectedUrl = new Uri("http://www.example.com");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new WwwRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void does_not_alter_url_without_www()
        {
            var inputUrl = new Uri("http://www.example.com");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new WwwRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(inputUrl));
        }
    }
}
