using System;

namespace Canonicalize.Rules
{
    /// <summary>
    /// URL canonicalization rule removing trailing slash characters from the end of the path.
    /// </summary>
    public class NoTrailingSlashRule : IRule
    {
        /// <summary>
        /// Removes any forward slashes (/) from the end of the part segment of the URL.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            uri.Path = uri.Path.TrimEnd('/');
        }
    }
}
