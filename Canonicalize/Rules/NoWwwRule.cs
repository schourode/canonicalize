using System;

namespace Canonicalize.Rules
{
    public class NoWwwRule : IRule
    {
        public void Apply(UriBuilder uri)
        {
            if (uri.Host.StartsWith("www."))
            {
                uri.Host = uri.Host.Substring(4);
            }
        }
    }
}
