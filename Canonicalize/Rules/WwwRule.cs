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
            if (uri.Uri.HostNameType == UriHostNameType.Dns && !uri.Host.StartsWith("www.") && !uri.Host.Equals("localhost", StringComparison.InvariantCultureIgnoreCase))
            {
                uri.Host = "www." + uri.Host;
            }
        }
    }
}
