using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public abstract class ConditionSectionBuilderBase<TBaseBuilder> : SectionBuilderBase<IConditionSectionBuilder<TBaseBuilder>>, IConditionSectionBuilder<TBaseBuilder> where TBaseBuilder : IPolicySectionBuilder
    {
        protected ConditionSectionBuilderBase(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        public abstract IConditionSectionBuilder<TBaseBuilder> When(string condition,
            Func<TBaseBuilder, ISectionPolicy> actionBuilder);

        public ISectionPolicy Otherwise(Func<TBaseBuilder, ISectionPolicy> actionBuilder)
        {
            return OtherwiseDefinition(actionBuilder).Create();
        }

        protected abstract IConditionSectionBuilder<TBaseBuilder> OtherwiseDefinition(Func<TBaseBuilder, ISectionPolicy> conditionSectionBuilder);
    }
}