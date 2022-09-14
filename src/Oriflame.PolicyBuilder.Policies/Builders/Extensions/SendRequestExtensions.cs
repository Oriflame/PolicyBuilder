using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SendRequestExtensions
    {
        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, TimeSpan timeout, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(variableName, timeout.GetSeconds(), sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, TimeSpan timeout, bool ignoreError, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(variableName, timeout.GetSeconds(), ignoreError, sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, TimeSpan timeout, bool ignoreError, RequestMode requestMode, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(variableName, timeout.GetSeconds(), ignoreError, requestMode, sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, string timeoutValue, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeoutValue), sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, string timeoutValue, bool ignoreError, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeoutValue, ignoreError), sendRequestBuilder);
        }

        public static T SendRequest<T>(this ISendRequest<T> builder, string variableName, string timeoutValue, bool ignoreError, RequestMode requestMode, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendRequest(attributesBuilder => attributesBuilder.Create(variableName, timeoutValue, ignoreError, requestMode), sendRequestBuilder);
        }
    }
}