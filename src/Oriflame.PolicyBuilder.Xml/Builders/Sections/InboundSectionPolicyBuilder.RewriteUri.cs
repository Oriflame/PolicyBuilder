using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder RewriteUri(string uriTemplate)
        {
            return AddPolicyDefinition(new RewriteUriPolicy(uriTemplate));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder RewriteUri(string uriTemplate, bool copyUnmatchedParams)
        {
            return AddPolicyDefinition(new RewriteUriPolicy(uriTemplate, copyUnmatchedParams));
        }
    }
}
