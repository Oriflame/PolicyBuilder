using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public IBackendSectionPolicyBuilder LimitConcurrency(string key, int maxCount, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action)
        {
            var limitConcurrency = new LimitConcurrency(key, maxCount);
            var innerPolicyBuilder = new BackendSectionPolicyBuilder(limitConcurrency);
            return AddPolicyDefinition(action.Invoke(innerPolicyBuilder));
        }

        /// <inheritdoc />
        public IBackendSectionPolicyBuilder LimitConcurrency(string key, string maxCount, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action)
        {
            var limitConcurrency = new LimitConcurrency(key, maxCount);
            var innerPolicyBuilder = new BackendSectionPolicyBuilder(limitConcurrency);
            return AddPolicyDefinition(action.Invoke(innerPolicyBuilder));
        }
    }
}