using System;

namespace Canonicalize.Rules
{
    /// <summary>
    /// URL canonicalization rule removing the www domain prefix if present.
    /// </summary>
    public class NoWwwRule : IRule
    {
        /// <summary>
        /// Removes a prefix of "www." from the host name if present.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            if (uri.Host.StartsWith("www."))
            {
                uri.Host = uri.Host.Substring(4);
            }
        }
    }
}
