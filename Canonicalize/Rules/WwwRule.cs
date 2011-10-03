using System;

namespace Canonicalize.Rules
{
    /// <summary>
    /// URL canonicalization rule ensuring a host name including the www domain prefix.
    /// </summary>
    public class WwwRule : IRule
    {
        /// <summary>
        /// Adds "www." to the beginning of the host name, if not present.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            if (!uri.Host.StartsWith("www."))
            {
                uri.Host = "www." + uri.Host;
            }
        }
    }
}
