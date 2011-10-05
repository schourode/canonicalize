using System.Collections.Generic;
using Canonicalize.Strategies;

namespace Canonicalize
{
    public static class CanonicalizeRouteBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="Strategies.Host"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <param name="host">Canonical DNS host name or IP address.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Host(this CanonicalizeRouteBuilder builder, string host)
        {
            return builder.Strategy(new Host(host));
        }

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
        /// Adds <see cref="Strategies.Map"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <param name="dictionary">Mapping between old paths (keys) and new paths (values).</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Map(this CanonicalizeRouteBuilder builder, IDictionary<string, string> dictionary)
        {
            return builder.Strategy(new Map(dictionary));
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
        /// Adds <see cref="Strategies.Pattern"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <param name="regex">The regular expression applied to the path.</param>
        /// <param name="replacement">Replacement string applied on match.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Pattern(this CanonicalizeRouteBuilder builder, string regex, string replacement)
        {
            return builder.Strategy(new Pattern(regex, replacement));
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
