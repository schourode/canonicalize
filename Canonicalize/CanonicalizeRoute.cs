using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace Canonicalize
{
    public class CanonicalizeRoute : RouteBase
    {
        private readonly IList<IUrlFilter> _filters = new List<IUrlFilter>();

        public ICollection<IUrlFilter> Filters
        {
            get { return _filters; }
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestedUrl = httpContext.Request.Url;
            var canonicalUrl = requestedUrl;

            foreach (var filter in _filters)
            {
                canonicalUrl = filter.Canonicalize(canonicalUrl);
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