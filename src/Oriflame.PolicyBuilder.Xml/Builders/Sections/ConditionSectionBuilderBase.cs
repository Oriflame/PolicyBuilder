using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public abstract class ConditionSectionBuilderBase<TBaseBuilder> : SectionBuilderBase<IConditionSectionBuilder<TBaseBuilder>>, IConditionSectionBuilder<TBaseBuilder> where TBaseBuilder : IPolicySectionBuilder
    {
        protected ConditionSectionBuilderBase() : base(new SectionPolicy("choose"))
        {
        }

        protected ISectionPolicy GetWhenSectionPolicy(string condition)
        {
            return new When(condition);
        }

        protected ISectionPolicy GetOtherwisePolicy()
        {
            return new SectionPolicy("otherwise");
        }

        protected IConditionSectionBuilder<TBaseBuilder> AddPolicyDefinition(TBaseBuilder innerBuilder, Func<TBaseBuilder, ISectionPolicy> conditionSectionBuilder)
        {
            return AddPolicyDefinition(conditionSectionBuilder.Invoke(innerBuilder));
        }

        public abstract IConditionSectionBuilder<TBaseBuilder> When(string condition, Func<TBaseBuilder, ISectionPolicy> actionBuilder);

        public ISectionPolicy Otherwise(Func<TBaseBuilder, ISectionPolicy> actionBuilder)
        {
            return OtherwiseDefinition(actionBuilder).Create();
        }

        protected abstract IConditionSectionBuilder<TBaseBuilder> OtherwiseDefinition(Func<TBaseBuilder, ISectionPolicy> conditionSectionBuilder);
    }
}