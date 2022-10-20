using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public override IBackendSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IBackendSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new BackendConditionSectionBuilder();
            return AddPolicyDefinition(conditionBuilder.Invoke(conditionSectionBuilder));
        }
    }
}