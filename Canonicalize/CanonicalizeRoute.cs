using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace Canonicalize
{
    public class CanonicalizeRoute : RouteBase
    {
        private readonly IList<IRule> _rules = new List<IRule>();

        public ICollection<IRule> Rules
        {
            get { return _rules; }
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestedUrl = httpContext.Request.Url;
            var canonicalUrl = requestedUrl;

            foreach (var rule in _rules)
            {
                canonicalUrl = rule.Canonicalize(canonicalUrl);
            }

            if (!requestedUrl.Equals(canonicalUrl))
            {
                var handler = new RedirectHandler(canonicalUrl);
                return new RouteData(this, handler);
            }

            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}