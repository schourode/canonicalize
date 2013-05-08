using System;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// Allows for custom URL canonicalization strategies defined using an <see cref="Action&lt;UrlBuilder&gt;"/>.
    /// </summary>
    public class CustomStrategy : IUrlStrategy
    {
        private readonly Action<UriBuilder> _action;

        /// <summary>
        /// Initializes a <see cref="CustomStrategy"/> as defined in an <see cref="Action&lt;UrlBuilder&gt;"/>.
        /// </summary>
        /// <param name="action">The canonicalization action to be applied to the URL.</param>
        public CustomStrategy(Action<UriBuilder> action)
        {
            _action = action;
        }

        /// <summary>
        /// Applies the custom URL canonicalization action to the URL.
        /// </summary>
        /// <param name="uri"></param>
        public void Apply(UriBuilder uri)
        {
            _action(uri);
        }
    }
}
