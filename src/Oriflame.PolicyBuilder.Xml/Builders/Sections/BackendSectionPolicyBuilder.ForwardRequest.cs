using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        public virtual IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout, Func<IForwardRequestAttributesBuilder, IDictionary<string, string>> forwardRequestOptionalAttributesBuilder)
        {
            var attributesBuilder = new ForwardRequestAttributesBuilder();
            var attributes = forwardRequestOptionalAttributesBuilder?.Invoke(attributesBuilder);
            var policy = new ForwardRequest(timeout?.GetSeconds(), attributes);
            return AddPolicyDefinition(policy);
        }
        
        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout)
        {
            return AddPolicyDefinition(new ForwardRequest(timeout?.GetSeconds()));
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(string timeoutValue)
        {
            return AddPolicyDefinition(new ForwardRequest(timeoutValue));
        }
    }
}