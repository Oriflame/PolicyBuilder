using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IBackendSectionPolicyBuilder : IPolicySectionBuilder<IBackendSectionPolicyBuilder>
    {
        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetBackendService"/>
        IBackendSectionPolicyBuilder SetBackendService(string url);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IBackendSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? existsAction);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IBackendSectionPolicyBuilder SetBody(ILiquidTemplate template);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        IBackendSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IBackendSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null);

        /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#ForwardRequest"/>
        IBackendSectionPolicyBuilder ForwardRequest(TimeSpan? timeout);
    }
}