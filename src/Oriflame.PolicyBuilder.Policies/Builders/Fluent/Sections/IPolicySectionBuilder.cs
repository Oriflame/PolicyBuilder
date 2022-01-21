using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IPolicySectionBuilder
    {
        //Creates section policy
        ISectionPolicy Create();
    }

    public interface IPolicySectionBuilder<TSection> : ISendRequest<TSection>, ISendOneWayRequest<TSection>, ISetHeaders<TSection>, ISetMethod<TSection>, ICacheValue<TSection>, ISetVariable<TSection>, IPolicySectionBuilder where TSection : IPolicySectionBuilder
    {
        //Calls base action for this section
        TSection Base();

        //Adds comment
        TSection Comment(string comment);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#ReturnResponse"/>
        ISectionPolicy ReturnResponse(Func<IReturnResponseSectionBuilder, ISectionPolicy> returnResponseBuilder);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Trace"/>
        TSection Trace(string sourceName, string content, Severity? severity = null);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Trace"/>
        TSection Trace(string source, string message = null, Severity? severity = null, Func<ITracePolicyBuilder, ISectionPolicy> action = null);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#choose"/>
        TSection Choose(Func<IConditionSectionBuilder<TSection>, ISectionPolicy> conditionBuilder);
    }
}