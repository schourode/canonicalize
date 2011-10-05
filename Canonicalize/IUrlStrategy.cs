using System;

namespace Canonicalize
{
    /// <summary>
    /// Defines the contract of a URL canonicalization strategy.
    /// </summary>
    public interface IUrlStrategy
    {
        /// <summary>
        /// Applies the canonicalization strategy to a URL. Changes can be made using the public setters on <see cref="UriBuilder"/>.
        /// If the URL is already in its canonical form the URL is not changed.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        void Apply(UriBuilder uri);
    }
}