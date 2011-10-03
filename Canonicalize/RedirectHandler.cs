using System;
using System.Web;
using System.Web.Routing;

namespace Canonicalize
{
    public class RedirectHandler : IRouteHandler, IHttpHandler
    {
        private readonly Uri _location;

        public RedirectHandler(Uri location)
        {
            _location = location;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Status = "301 Moved Permanently";
            context.Response.AppendHeader("Location", _location.ToString());
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}