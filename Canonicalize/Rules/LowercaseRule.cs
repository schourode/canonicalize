using System;

namespace Canonicalize.Rules
{
    public class LowercaseRule : IRule
    {
        public void Apply(UriBuilder uri)
        {
            uri.Path = uri.Path.ToLowerInvariant();
        }
    }
}
