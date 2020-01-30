using System;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IConditionSectionBuilder<out TSectionBuilder> : IPolicySectionBuilder where TSectionBuilder : IPolicySectionBuilder
    {
        IConditionSectionBuilder<TSectionBuilder> When(string condition, Func<TSectionBuilder, ISectionPolicy> actionBuilder);

        ISectionPolicy Otherwise(Func<TSectionBuilder, ISectionPolicy> actionBuilder);

        //Adds comment
        IConditionSectionBuilder<TSectionBuilder> Comment(string comment);
    }
}