using System.Collections.Generic;
using Canonicalize.Strategies;

namespace Canonicalize
{
    public static class CanonicalizeRouteBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="Strategies.HostStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <param name="host">Canonical DNS host name or IP address.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Host(this CanonicalizeRouteBuilder builder, string host)
        {
            return builder.Strategy(new HostStrategy(host));
        }

        /// <summary>
        /// Adds <see cref="Strategies.LowercaseStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Lowercase(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new LowercaseStrategy());
        }

        /// <summary>
        /// Adds <see cref="Strategies.MapStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <param name="dictionary">Mapping between old paths (keys) and new paths (values).</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Map(this CanonicalizeRouteBuilder builder, IDictionary<string, string> dictionary)
        {
            return builder.Strategy(new MapStrategy(dictionary));
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoTrailingSlashStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder NoTrailingSlash(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new NoTrailingSlashStrategy());
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoWwwStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder NoWww(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new NoWwwStrategy());
        }

        /// <summary>
        /// Adds <see cref="Strategies.PatternStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <param name="regex">The regular expression applied to the path.</param>
        /// <param name="replacement">Replacement string applied on match.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Pattern(this CanonicalizeRouteBuilder builder, string regex, string replacement)
        {
            return builder.Strategy(new PatternStrategy(regex, replacement));
        }

        /// <summary>
        /// Adds <see cref="Strategies.TrailingSlashStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder TrailingSlash(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new TrailingSlashStrategy());
        }

        /// <summary>
        /// Adds <see cref="Strategies.NoWwwStrategy"/> to the strategy collection.
        /// </summary>
        /// <param name="builder">Reponsible for building the <see cref="CanonicalizeRoute"/>.</param>
        /// <returns>itself, allowing additional method calls to be chained.</returns>
        public static CanonicalizeRouteBuilder Www(this CanonicalizeRouteBuilder builder)
        {
            return builder.Strategy(new WwwStrategy());
        }
    }
}
