# URL canonicalization with ASP.NET (MVC) routing

The default URL routing setup in an ASP.NET application (MVC or web forms), using the `System.Web.Routing` framework, is very forgiving. For instance, it does not care about upper vs lower case, about trailing slashes or host names. This can be a problem if you care about search engine optimization (SEO), as the relaxed URL handling yields duplicate content.

*Canonicalize* complements the ASP.NET routing engine with a configurable `CanonicalizeRoute`, which will handle requests to non-canonical URLs by permanently redirecting (HTTP 301) to the canonical URL.

## Installation

Install the package via NuGet:

    Install-Package Canonicalize

In your route registration (typically in `Global.asax.cs`) add the following, *before* any existing registrations:

    routes.Canonicalize().Www().Lowercase().NoTrailingSlash();

The line above adds a `CanonicalizeRoute` to your routing table and adds three canonicalization strategies to its configuration. Remove any strategy you do not require, and use IntelliSense to explore what other strategies are available or consult the list below.

## Built-in strategies

* `Lowercase` will ensure that all characters in the path are lowercase.
* `Www / NoWww` will redirect from example.com to www.example.com or vice versa.
* `TrailingSlash / NoTrailingSlash` will add or remove a trailing slash from the path.
* `Host` will redirect all requests to a specific DNS host name or IP address.
* `Map` will lookup the path in a dictionary to find a new path.
* `Pattern` performs a search/replace on the path against a regular expression.

## Custom strategies

Defining your own URL canonicalization strategies requires you to implement the one-method `IUrlStrategy` interface. Then use the more verbose route setup syntax:

    routes.Add(new CanonicalizeRoute(new LowercaseStrategy(), new CustomStrategy()));

In order to enable fluent configuration with your new strategy, you must also add an extension method to `CanonicalizeRouteBuilder`. If you find that your strategy might be useful for others, consider sending in a patch.

## License

*Canonicalize* is released under the MIT license.
