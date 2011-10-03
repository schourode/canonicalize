using Canonicalize.Rules;

namespace Canonicalize
{
    public class CanonicalizeRouteBuilder
    {
        private readonly CanonicalizeRoute _route;

        public CanonicalizeRouteBuilder(CanonicalizeRoute route)
        {
            _route = route;
        }

        public CanonicalizeRouteBuilder Lowercase()
        {
            _route.Rules.Add(new LowercaseRule());
            return this;
        }

        public CanonicalizeRouteBuilder NoWww()
        {
            _route.Rules.Add(new NoWwwRule());
            return this;
        }

        public CanonicalizeRouteBuilder Www()
        {
            _route.Rules.Add(new WwwRule());
            return this;
        }
    }
}
