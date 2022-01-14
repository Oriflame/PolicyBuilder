using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SendOneWayRequestAttributesBuilderExtensions
    {
        public static IDictionary<string, string> Create(this ISendOneWayRequestAttributesBuilder builder, RequestMode requestMode = RequestMode.New)
        {
            return builder.Mode(requestMode)
                .Create();
        }
    }
}