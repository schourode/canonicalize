using System;

namespace Canonicalize
{
    /// <summary>
    /// Defines the contract of a URL canonicalization rule.
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Applies the canonicalization rule to a URL. Changes can be made using the public setters on <see cref="UriBuilder"/>.
        /// If the URL is already in its canonical form the URL is not changed.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        void Apply(UriBuilder uri);
    }
}