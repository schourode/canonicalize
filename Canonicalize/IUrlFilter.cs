using System;

namespace Canonicalize
{
    public interface IUrlFilter
    {
        Uri Canonicalize(Uri canonicalUrl);
    }
}