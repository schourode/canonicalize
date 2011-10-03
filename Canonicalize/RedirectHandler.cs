using System;
using System.Web;
using System.Web.Routing;

namespace Canonicalize
{
    /// <summary>
    /// Implements <see cref="IRouteHandler"/> and <see cref="IHttpHandler"/> to send a permanent redirect (HTTP status code 301).
    /// </summary>
    public class RedirectHandler : IRouteHandler, IHttpHandler
    {
        private readonly Uri _location;

        /// <summary>
        /// Initializes a <see cref="RedirectHandler"/> with a provided redurict URL.
        /// </summary>
        /// <param name="location">The URL to which the request should be redirected.</param>
        public RedirectHandler(Uri location)
        {
            _location = location;
        }

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns>Itself.</returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        /// <summary>
        /// Redirects a HTTP request by setting the status code and the Location header.
        /// </summary>
        /// <param name="context">An <see cref="HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Status = "301 Moved Permanently";
            context.Response.AppendHeader("Location", _location.ToString());
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the IHttpHandler instance.
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }
    }
}