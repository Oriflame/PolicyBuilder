using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SendRequestExtensions
    {
        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, TimeSpan timeout, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeout), sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, TimeSpan timeout, bool ignoreError, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeout, ignoreError), sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, TimeSpan timeout, bool ignoreError, RequestMode requestMode, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeout, ignoreError, requestMode), sendRequestBuilder);
        }
    }
}