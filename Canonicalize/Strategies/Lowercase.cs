using System;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// URL canonicalization strategy enforcing that all characters in the path are lower case.
    /// </summary>
    public class Lowercase : IUrlStrategy
    {
        /// <summary>
        /// Converts any upper case characters in the path segment of the URL to their lower case equivalent.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            uri.Path = uri.Path.ToLowerInvariant();
        }
    }
}
