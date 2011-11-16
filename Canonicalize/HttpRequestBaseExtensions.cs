using System;
using System.Web;

namespace Canonicalize
{
    /// <summary>
    /// Adds extension methods on <see cref="HttpRequestBase"/>.
    /// </summary>
    public static class HttpRequestBaseExtensions
    {
        /// <summary>
        /// Gets the original URL requested by the client, without artifacts from proxies or load balancers.
        /// In particular HTTP headers Host, X-Forwarded-Host, X-Forwarded-Proto are applied on top of <see cref="HttpRequestBase.Url"/>.
        /// </summary>
        /// <param name="request">The request for which the original URL should be computed.</param>
        /// <returns>The original URL requested by the client.</returns>
        public static Uri GetOriginalUrl(this HttpRequestBase request)
        {
            if (request.Url == null || request.Headers == null)
            {
                return request.Url;
            }

            var uriBuilder = new UriBuilder(request.Url);

            var forwardedProtocol = request.Headers["X-Forwarded-Proto"];
            if (forwardedProtocol != null)
            {
                uriBuilder.Scheme = forwardedProtocol;
            }

            var hostHeader = request.Headers["X-Forwarded-Host"] ?? request.Headers["Host"];
            if (hostHeader != null)
            {
                var parsedHost = new Uri(uriBuilder.Scheme + Uri.SchemeDelimiter + hostHeader);
                uriBuilder.Host = parsedHost.Host;
                uriBuilder.Port = parsedHost.Port;
            }

            return uriBuilder.Uri;
        }
    }
}
