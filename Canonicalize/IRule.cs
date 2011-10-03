using System;

namespace Canonicalize
{
    public interface IRule
    {
        void Apply(UriBuilder uri);
    }
}