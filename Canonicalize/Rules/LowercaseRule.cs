using System;

namespace Canonicalize.Rules
{
    public class LowercaseRule : IRule
    {
        public Uri Canonicalize(Uri inputUrl)
        {
            var path = inputUrl.AbsolutePath;
            var lowerPath = path.ToLowerInvariant();

            if (path == lowerPath)
            {
                return inputUrl;
            }

            return new Uri(inputUrl, lowerPath + inputUrl.Query);
        }
    }
}
