using System;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;
using Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.Providers
{
    public static class ContextProvider
    {
        // Implement singleton pattern
        private static readonly Lazy<IContext> _context = new Lazy<IContext>(() => new Context());

        public static IContext Context => _context.Value;
    }
}
