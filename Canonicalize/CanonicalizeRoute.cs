using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace Canonicalize
{
    /// <summary>
    /// Checks incoming requests against a collection of rules and redirects to a canonical URL if applicable.
    /// </summary>
    public class CanonicalizeRoute : RouteBase
    {
        private readonly IList<IRule> _rules;

        /// <summary>
        /// Initializes a <see cref="CanonicalizeRoute"/> with an empty rule collection.
        /// </summary>
        public CanonicalizeRoute()
        {
            _rules = new List<IRule>();
        }

        /// <summary>
        /// Initializes a <see cref="CanonicalizeRoute"/> with a specified set of rules.
        /// </summary>
        /// <param name="rules">Rules to be initially added to the <see cref="Rules"/> collection.</param>
        public CanonicalizeRoute(params IRule[] rules)
        {
            _rules = new List<IRule>(rules);
        }

        /// <summary>
        /// Gets the collection of rules to apply to incoming URLs.
        /// </summary>
        public ICollection<IRule> Rules
        {
            get { return _rules; }
        }

        /// <summary>
        /// Applies each <see cref="Rules"/> in turn. Only if the result differs from the originally requested URL a redirect is returned.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <returns>Route data with a <see cref="RedirectHandler"/> if any rules were triggered, otherwise null.</returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestedUri = httpContext.Request.Url;
            var uriBuilder = new UriBuilder(requestedUri);

            foreach (var rule in _rules)
            {
                rule.Apply(uriBuilder);
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