using System;
using System.Collections.Generic;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// URL canonicalization strategy using a map/dictionary data structure to map old paths to new ones.
    /// </summary>
    public class MapStrategy : IUrlStrategy
    {
        private readonly IDictionary<string, string> _dictionary;

        /// <summary>
        /// Initializes a <see cref="MapStrategy"/> with a specific backing dictionary.
        /// </summary>
        /// <param name="dictionary">Mapping between old paths (keys) and new paths (values).</param>
        public MapStrategy(IDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }

        /// <summary>
        /// Makes a lookup in the backing dictionary for the path and replaces it if matched.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            string newPath;

            if (_dictionary.TryGetValue(uri.Path, out newPath))
            {
                uri.Path = newPath;
            }
        }
    }
}
