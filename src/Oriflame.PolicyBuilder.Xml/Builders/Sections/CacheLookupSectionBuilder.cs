using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class CacheLookupSectionBuilder : SectionBuilderBase<ICacheLookupSectionBuilder>, ICacheLookupSectionBuilder
    {
        public CacheLookupSectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("cache-lookup", attributes))
        {
        }

        public ICacheLookupSectionBuilder VaryByHeader(string value)
        {
            return AddPolicyDefinition(new VaryByHeader(value));
        }

        public ICacheLookupSectionBuilder VaryByQueryParameter(string value)
        {
            return AddPolicyDefinition(new VaryByQueryParameter(value));
        }
    }
}