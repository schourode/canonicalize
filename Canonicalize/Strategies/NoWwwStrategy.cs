using System;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// URL canonicalization strategy removing the www domain prefix if present.
    /// </summary>
    public class NoWwwStrategy : IUrlStrategy
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
