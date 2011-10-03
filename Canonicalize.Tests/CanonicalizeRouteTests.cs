using System;
using System.Web;
using Moq;
using NUnit.Framework;

namespace Canonicalize.Tests
{
    class CanonicalizeRouteTests
    {
        [Test]
        public void route_without_filters_not_routed()
        {
            var route = new CanonicalizeRoute();
            var inputUrl = new Uri("http://example.com");
            var context = CreateFakeHttpContext(inputUrl);
            
            var routeData = route.GetRouteData(context);

            Assert.Null(routeData);
        }

        [Test]
        public void route_filters_are_invoked()
        {
            var filter = new Mock<IUrlFilter>();
            var inputUrl = new Uri("http://example.com");
            filter.Setup(x => x.Canonicalize(inputUrl)).Returns(inputUrl).Verifiable();

            var route = new CanonicalizeRoute();
            route.Filters.Add(filter.Object);

            var context = CreateFakeHttpContext(inputUrl);

            route.GetRouteData(context);

            filter.Verify();
        }

        [Test]
        public void route_with_nonchanging_filter_not_routed()
        {
            var filter = new Mock<IUrlFilter>();
            var inputUrl = new Uri("http://example.com");
            filter.Setup(x => x.Canonicalize(inputUrl)).Returns(inputUrl);

            var route = new CanonicalizeRoute();
            route.Filters.Add(filter.Object);

            var context = CreateFakeHttpContext(inputUrl);
            
            var routeData = route.GetRouteData(context);

            Assert.Null(routeData);
        }

        [Test]
        public void route_with_changing_filter_routed()
        {
            var filter = new Mock<IUrlFilter>();
            var inputUrl = new Uri("http://example.com");
            var outputUrl = new Uri("http://example.net");
            filter.Setup(x => x.Canonicalize(inputUrl)).Returns(outputUrl);

            var route = new CanonicalizeRoute();
            route.Filters.Add(filter.Object);

            var context = CreateFakeHttpContext(inputUrl);
            var routeData = route.GetRouteData(context);

            Assert.NotNull(routeData);
            Assert.NotNull(routeData.RouteHandler);
            Assert.IsInstanceOf<RedirectHandler>(routeData.RouteHandler);
        }

        private static HttpContextBase CreateFakeHttpContext(Uri url)
        {
            return Mock.Of<HttpContextBase>(x =>
                x.Request == Mock.Of<HttpRequestBase>(y =>
                    y.Url == url
                ) &&
                x.Response == Mock.Of<HttpResponseBase>()
            );
        }
    }
}
