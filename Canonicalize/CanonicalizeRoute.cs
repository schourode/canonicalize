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

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}