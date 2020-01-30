using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SendRequestsExtensions
    {
        public static T SendRequest<T>(this ISendRequests<T> builder, string variableName, TimeSpan timeout, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeout), sendRequestBuilder);
        }
    }
}