using System;

namespace Canonicalize.Rules
{
    /// <summary>
    /// URL canonicalization rule ensuring a slash as the last character of the part.
    /// </summary>
    public class TrailingSlashRule : IRule
    {
        /// <summary>
        /// Adds a forward slash (/) to the end of the part segment of the URL, if not already present.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            if (!uri.Path.EndsWith("/"))
            {
                uri.Path += '/';
            }
        }
    }
}
