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

    public interface IPolicySectionBuilder<TSection> : ISendRequests<TSection>, ISetHeaders<TSection>, ISetMethod<TSection>, ICacheValue<TSection>, ISetVariable<TSection>, IPolicySectionBuilder where TSection : IPolicySectionBuilder 
    {
        //Calls base action for this section
        TSection Base();

        //Adds comment
        TSection Comment(string comment);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#ReturnResponse"/>
        ISectionPolicy ReturnResponse(Func<IReturnResponseSectionBuilder, ISectionPolicy> returnResponseBuilder);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Trace"/>
        TSection Trace(string sourceName, string content);
       

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#choose"/>
        TSection Choose(Func<IConditionSectionBuilder<TSection>, ISectionPolicy> conditionBuilder);
    }
}