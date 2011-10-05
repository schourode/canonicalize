using System;
using System.Text.RegularExpressions;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// URL canonicalization strategy using a pattern described as a regular expression to modify the path.
    /// </summary>
    public class Pattern : IUrlStrategy
    {
        private readonly Regex _regex;
        private readonly string _replacement;

        /// <summary>
        /// Initializes a <see cref="Pattern"/> with a specific regular expression and replacement string.
        /// </summary>
        /// <param name="regex">The regular expression applied to the path.</param>
        /// <param name="replacement">Replacement string applied on match.</param>
        public Pattern(string regex, string replacement)
        {
            _regex = new Regex(regex, RegexOptions.Compiled);
            _replacement = replacement;
        }

        /// <summary>
        /// Matches the path of the URL against the pattern and assigns the replacement string (with substitutions) if matching.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            uri.Path = _regex.Replace(uri.Path, _replacement);
        }
    }
}
