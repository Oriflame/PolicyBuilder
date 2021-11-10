using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#SendRequest"/>
    public interface ISendRequests<T> where T : IPolicySectionBuilder
    {
        T SendRequest(Func<ISendRequestAttributesBuilder, IDictionary<string, string>> sendRequestAttributesBuilder,
            Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder);
    }
}