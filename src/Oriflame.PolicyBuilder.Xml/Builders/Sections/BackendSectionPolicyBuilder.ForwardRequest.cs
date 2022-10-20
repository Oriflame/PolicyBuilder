using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout)
        {
            return AddPolicyDefinition(new ForwardRequest(timeout));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(string timeoutValue)
        {
            return AddPolicyDefinition(new ForwardRequest(timeoutValue));
        }
    }
}