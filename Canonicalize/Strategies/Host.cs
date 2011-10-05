﻿using System;

namespace Canonicalize.Strategies
{
    /// <summary>
    /// URL canonicalization strategy enforcing use of a specific DNS host name or IP address.
    /// </summary>
    public class Host : IUrlStrategy
    {
        private readonly string _host;

        /// <summary>
        /// Initializes a <see cref="Host"/> with a specific DNS host name or IP address.
        /// </summary>
        /// <param name="host">Canonical DNS host name or IP address.</param>
        public Host(string host)
        {
            _host = host;
        }

        /// <summary>
        /// Replaces the host part of the URL with the canonical host.
        /// </summary>
        /// <param name="uri">The URL to be canonicalized.</param>
        public void Apply(UriBuilder uri)
        {
            uri.Host = _host;
        }
    }
}
