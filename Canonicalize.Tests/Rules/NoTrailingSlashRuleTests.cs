using System;
using Canonicalize.Rules;
using NUnit.Framework;

namespace Canonicalize.Tests.Rules
{
    public class NoTrailingSlashRuleTests
    {
        [Test]
        public void removes_slash_when_present()
        {
            var inputUrl = new Uri("http://example.com/foobar/");
            var expectedUrl = new Uri("http://example.com/foobar");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new NoTrailingSlashRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void does_not_alter_url_without_slash()
        {
            var inputUrl = new Uri("http://www.example.com/foobar");
            var uriBuilder = new UriBuilder(inputUrl);

            IRule rule = new NoTrailingSlashRule();
            rule.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(inputUrl));
        }
    }
}
