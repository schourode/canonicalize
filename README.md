# URL canonicalization with ASP.NET (MVC) routing

The default URL routing setup in an ASP.NET application (MVC or web forms), using the `System.Web.Routing` framework, is very forgiving. For instance, it does not care about upper vs lower case, about trailing slashes or host names. This can be a problem if you care about search engine optimization (SEO), as the relaxed URL rules yields duplicate content.

*Canonicalize* complements the ASP.NET routing engine with a configurable `CanonicalizeRoute`, which will handle requests to non-canonical URLs by permanently redirecting (HTTP 301) to the canonical URL.

## Installation

Install the package via NuGet:

    Install-Package Canonicalize

In your route registration (typically in `Global.asax.cs`) add the following, *before* any existing registrations:

    routes.Canonicalize().Www().Lowercase().NoTrailingSlash();

The line above adds a `CanonicalizeRoute` to your routing table and adds three rules to its configuration. Remove any rule you do not require, and use IntelliSense to explore what other rules are available or consult the list below.

## Built-in rules

* `Lowercase` will ensure that all characters in the path are lowercase.
* `Www / NoWww` will redirect from example.com to www.example.com or vice versa.
* `TrailingSlash / NoTrailingSlash` will add or remove a trailing slash from the path.

## Custom rules

Defining your own URL canonicalization rules requires you to implement the one-method `IRule` interface. Then use the more verbose route setup syntax:

    routes.Add(new CanonicalizeRoute(new WwwRule(), new CustomRule()));

In order to enable fluent configuration with your new rule, you must also add an extension method to `CanonicalizeRouteBuilder`. If you find that your rule might be useful for others, consider sending in a patch.

## License

*Canonicalize* is released under the MIT license.
