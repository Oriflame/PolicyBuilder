using System;
using System.Collections.Generic;
using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? skip)
        {
            return AddPolicyDefinition(new SetQueryParameter(name, value, skip));
        }
    }
}