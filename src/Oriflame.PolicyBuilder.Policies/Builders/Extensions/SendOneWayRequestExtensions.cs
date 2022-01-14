using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SendOneWayRequestExtensions
    {
        public static T SendOneWayRequest<T>(this ISendOneWayRequest<T> builder, Func<ISendOneWayRequestSectionBuilder, ISectionPolicy> sendOneWayRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendOneWayRequest(attributesBuilder => attributesBuilder.Create(), sendOneWayRequestBuilder);
        }

        public static T SendOneWayRequest<T>(this ISendOneWayRequest<T> builder, RequestMode requestMode, Func<ISendOneWayRequestSectionBuilder, ISectionPolicy> sendOneWayRequestBuilder) where T : IPolicySectionBuilder
        {
            return builder.SendOneWayRequest(attributesBuilder => attributesBuilder.Create(requestMode), sendOneWayRequestBuilder);
        }
    }
}