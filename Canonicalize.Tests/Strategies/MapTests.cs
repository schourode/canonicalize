using System;
using System.Collections.Generic;
using Canonicalize.Strategies;
using NUnit.Framework;

namespace Canonicalize.Tests.Strategies
{
    class MapTests
    {
        [TestCase("http://example.com/foo", "http://example.com/bar", TestName = "Match")]
        [TestCase("http://example.com/foo/more", "http://example.com/foo/more", TestName = "No nested match")]
        [TestCase("http://example.com/bom", "http://example.com/bom", TestName = "No match")]
        public void AssertUrlChange(string originalUrl, string expectedCanonicalUrl)
        {
            var uriBuilder = new UriBuilder(originalUrl);

            var dictionary = new Dictionary<string, string>
            {
                {"/foo", "/bar"}
            };

            IUrlStrategy strategy = new Map(dictionary);
            strategy.Apply(uriBuilder);

            Assert.That(uriBuilder.Uri, Is.EqualTo(new Uri(expectedCanonicalUrl)));
        }
    }
}
