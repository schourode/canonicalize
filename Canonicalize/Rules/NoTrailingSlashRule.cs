using System;

namespace Canonicalize.Rules
{
    public class NoTrailingSlashRule : IRule
    {
        public void Apply(UriBuilder uri)
        {
            if (uri.Path.EndsWith("/"))
            {
                uri.Path = uri.Path.Substring(0, uri.Path.Length - 1);
            }
        }
    }
}
