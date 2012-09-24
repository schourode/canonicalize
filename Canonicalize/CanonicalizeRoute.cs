using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace Canonicalize
{
    /// <summary>
    /// Applies a number of canonicalization strategies to the requested URL and redirects if applicable.
    /// </summary>
    public class CanonicalizeRoute : RouteBase
    {
        private readonly IList<IUrlStrategy> _strategies;

        /// <summary>
        /// Initializes a <see cref="CanonicalizeRoute"/> with an empty strategy collection.
        /// </summary>
        public CanonicalizeRoute()
        {
            _strategies = new List<IUrlStrategy>();
        }

        /// <summary>
        /// Initializes a <see cref="CanonicalizeRoute"/> with a specified set of strategies.
        /// </summary>
        /// <param name="strategies">Strategies to be initially added to the <see cref="Strategies"/> collection.</param>
        public CanonicalizeRoute(params IUrlStrategy[] strategies)
        {
            _strategies = new List<IUrlStrategy>(strategies);
        }

        /// <summary>
        /// Gets the collection of strategies to apply to incoming URLs.
        /// </summary>
        public ICollection<IUrlStrategy> Strategies
        {
            get { return _strategies; }
        }

        /// <summary>
        /// Applies each <see cref="Strategies"/> in turn. Only if the result differs from the originally requested URL a redirect is returned.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <returns>Route data with a <see cref="RedirectHandler"/> if any strategies were triggered, otherwise null.</returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            switch (httpContext.Request.HttpMethod.ToUpperInvariant())
            {
                case "GET":
                case "HEAD":
                    return GetCanonicalizedRouteData(httpContext);

                default:
                    return null;
            }
        }

        private RouteData GetCanonicalizedRouteData(HttpContextBase httpContext)
        {
            var requestedUri = httpContext.Request.GetOriginalUrl();
            var uriBuilder = new UriBuilder(requestedUri);

            foreach (var strategy in _strategies)
            {
                strategy.Apply(uriBuilder);
            }

            if (!requestedUri.Equals(uriBuilder.Uri))
            {
                var handler = new RedirectHandler(uriBuilder.Uri);
                return new RouteData(this, handler);
            }

            return null;
        }

        /// <summary>
        /// Returns null, allowing other routes to provide the canonical URL for the requested route values.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the requested route.</param>
        /// <param name="values">An object that contains the parameters for a route.</param>
        /// <returns>Always null.</returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}