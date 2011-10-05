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
        /// Adds a new canonicalization strategy to the <see cref="CanonicalizeRoute"/>.
        /// </summary>
        /// <param name="strategy">The canonicalization strategy to be added.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public CanonicalizeRouteBuilder Strategy(IUrlStrategy strategy)
        {
            _route.Strategies.Add(strategy);
            return this;
        }
    }
}
