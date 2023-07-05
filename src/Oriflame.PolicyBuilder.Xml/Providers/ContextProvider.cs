using System;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;

namespace Oriflame.PolicyBuilder.Xml.Providers
{
    public static class ContextProvider
    {
        // Implement singleton pattern
        private static readonly Lazy<Context> _context = new Lazy<Context>(() => new Context());

        public static Context Context => _context.Value;
    }
}
