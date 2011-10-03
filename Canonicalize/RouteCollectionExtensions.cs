using System.Web.Routing;

namespace Canonicalize
{
    public static class RouteCollectionExtensions
    {
        public static CanonicalizeRouteBuilder Canonicalize(this RouteCollection routes)
        {
            var route = new CanonicalizeRoute();
            routes.Add(route);

            return new CanonicalizeRouteBuilder(route);
        }
    }
}
