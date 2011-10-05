using Canonicalize.Strategies;

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
        /// Adds <see cref="Strategies.Lowercase"/> to the strategy collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder Lowercase()
        {
            _route.Strategies.Add(new Lowercase());
            return this;
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoTrailingSlash"/> to the strategy collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder NoTrailingSlash()
        {
            _route.Strategies.Add(new NoTrailingSlash());
            return this;
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoWww"/> to the strategy collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder NoWww()
        {
            _route.Strategies.Add(new NoWww());
            return this;
        }

        /// <summary>
        /// Adds <see cref="Strategies.TrailingSlash"/> to the strategy collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder TrailingSlash()
        {
            _route.Strategies.Add(new TrailingSlash());
            return this;
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoWww"/> to the strategy collection.
        /// </summary>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder Www()
        {
            _route.Strategies.Add(new Www());
            return this;
        }
    }
}
