using Canonicalize.Strategies;

namespace Canonicalize
{
    public static class CanonicalizeRouteBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="Strategies.Lowercase"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Lowercase(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new Lowercase());
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoTrailingSlash"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder NoTrailingSlash(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new NoTrailingSlash());
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoWww"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder NoWww(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new NoWww());
        }

        /// <summary>
        /// Adds <see cref="Strategies.TrailingSlash"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder TrailingSlash(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new TrailingSlash());
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoWww"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Www(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new Www());
        }
    }
}
