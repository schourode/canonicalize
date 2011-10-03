using Canonicalize.Rules;

namespace Canonicalize
{
    /// <summary>
    /// Exposes a fluent API with chainable methods for configuring a <see cref="CanonicalizeRoute"/>.
    /// </summary>
    public class CanonicalizeRouteBuilder
    {
        private readonly CanonicalizeRoute _route;

        /// <summary>
        /// Initializes a <see cref="CanonicalizeRouteBuilder"/> for configuration of a specific <see cref="CanonicalizeRoute"/>.
        /// </summary>
        /// <param name="route">The route to be configured using the fluent API.</param>
        public CanonicalizeRouteBuilder(CanonicalizeRoute route)
        {
            _route = route;
        }

        /// <summary>
        /// Adds <see cref="LowercaseRule"/> to the rule collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder Lowercase()
        {
            _route.Rules.Add(new LowercaseRule());
            return this;
        }

        /// <summary>
        /// Adds <see cref="NoTrailingSlashRule"/> to the rule collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder NoTrailingSlash()
        {
            _route.Rules.Add(new NoTrailingSlashRule());
            return this;
        }

        /// <summary>
        /// Adds <see cref="NoWwwRule"/> to the rule collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder NoWww()
        {
            _route.Rules.Add(new NoWwwRule());
            return this;
        }

        /// <summary>
        /// Adds <see cref="TrailingSlashRule"/> to the rule collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder TrailingSlash()
        {
            _route.Rules.Add(new TrailingSlashRule());
            return this;
        }

        /// <summary>
        /// Adds <see cref="NoWwwRule"/> to the rule collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder Www()
        {
            _route.Rules.Add(new WwwRule());
            return this;
        }
    }
}
