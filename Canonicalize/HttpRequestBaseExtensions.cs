using System;
using System.Web;

namespace Canonicalize
{
    internal static class HttpRequestBaseExtensions
    {
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
