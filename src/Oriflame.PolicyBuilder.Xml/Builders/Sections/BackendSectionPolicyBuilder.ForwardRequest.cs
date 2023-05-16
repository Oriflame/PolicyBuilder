using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout, bool bufferResponse)
        {
            return AddPolicyDefinition(new ForwardRequest(timeout?.GetSeconds(), bufferResponse));
        }
        
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