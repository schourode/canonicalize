using System;

namespace Canonicalize
{
    public interface IRule
    {
        Uri Canonicalize(Uri canonicalUrl);
    }
}