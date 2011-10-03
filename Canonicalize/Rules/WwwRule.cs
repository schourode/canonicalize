using System;

namespace Canonicalize.Rules
{
    public class WwwRule : IRule
    {
        public void Apply(UriBuilder uri)
        {
            if (!uri.Host.StartsWith("www."))
            {
                uri.Host = "www." + uri.Host;
            }
        }
    }
}
