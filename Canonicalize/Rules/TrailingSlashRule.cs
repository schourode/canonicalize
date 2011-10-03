using System;

namespace Canonicalize.Rules
{
    public class TrailingSlashRule : IRule
    {
        public void Apply(UriBuilder uri)
        {
            if (!uri.Path.EndsWith("/"))
            {
                uri.Path += '/';
            }
        }
    }
}
