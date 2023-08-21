using System;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.Expressions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSection"></typeparam>
    public interface IRetry<TSection>
    {
        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(Expression condition, int count, TimeSpan interval, Func<TSection, ISectionPolicy> action, bool? firstFastRetry = null);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(Expression condition, Expression count, TimeSpan interval, Func<TSection, ISectionPolicy> action, bool? firstFastRetry = null);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(Expression condition, int count, Expression interval, Func<TSection, ISectionPolicy> action, bool? firstFastRetry = null);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(Expression condition, int count, TimeSpan interval, Func<TSection, ISectionPolicy> action, Expression firstFastRetry);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(Expression condition, Expression count, Expression interval, Func<TSection, ISectionPolicy> action, Expression firstFastRetry);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        TSection Retry(Expression condition, Expression count, Expression interval, Func<TSection, ISectionPolicy> action, bool? firstFastRetry = null);
    }
}
