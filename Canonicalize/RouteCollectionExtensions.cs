using System.Web.Routing;

namespace Canonicalize
{
    /// <summary>
    /// Adds an extension method on <see cref="RouteCollection"/> enabling the fluent API.
    /// </summary>
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Adds a <see cref="CanonicalizeRoute"/> to the route collection and returns a <see cref="CanonicalizeRouteBuilder"/> for fluent configuration.
        /// </summary>
        /// <param name="routes">The collection to which the <see cref="CanonicalizeRoute"/> is to be added.</param>
        /// <returns>Entry object for fluent URL canonicaliztion configuration.</returns>
        public static CanonicalizeRouteBuilder Canonicalize(this RouteCollection routes)
        {
            var route = new CanonicalizeRoute();
            routes.Add(route);

            return new CanonicalizeRouteBuilder(route);
        }
    }
}
