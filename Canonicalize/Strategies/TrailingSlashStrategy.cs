using System;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// URL canonicalization strategy ensuring a slash as the last character of the path for non-file URLs.
    /// </summary>
    public sealed class TrailingSlashStrategy : IUrlStrategy
    {
        /// <summary>
        /// Adds a forward slash (/) to the end of the part segment of the URL, if not already present.
        /// No slash is added if the URL contains a period (.) indicating a file extension.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            if (!uri.Path.EndsWith("/") && !uri.Path.Contains("."))
            {
                uri.Path += '/';
            }
        }
    }
}
