using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        public virtual IBackendSectionPolicyBuilder ForwardRequest(Func<IForwardRequestAttributesBuilder, IDictionary<string, string>> forwardRequestOptionalAttributesBuilder)
        {
            var attributesBuilder = new ForwardRequestAttributesBuilder();
            var attributes = forwardRequestOptionalAttributesBuilder?.Invoke(attributesBuilder);
            var policy = new ForwardRequest(attributes);
            return AddPolicyDefinition(policy);
        }
        
        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout)
        {
            return timeout.HasValue ? ForwardRequest(builder => builder.Timeout(timeout.Value).Create()) : ForwardRequest(builder => builder.Create());
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder ForwardRequest(string timeoutValue)
        {
            return ForwardRequest(TimeSpan.FromSeconds(Convert.ToInt32(timeoutValue)));
        }
    }
}