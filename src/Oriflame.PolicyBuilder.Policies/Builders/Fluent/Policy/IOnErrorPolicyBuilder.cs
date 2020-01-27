using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy
{
    public interface IOnErrorPolicyBuilder
    {
        IPolicyBuilderTerminator OnError(Func<IOnErrorSectionPolicyBuilder, ISectionPolicy> buildOnErrorSection);
    }
}