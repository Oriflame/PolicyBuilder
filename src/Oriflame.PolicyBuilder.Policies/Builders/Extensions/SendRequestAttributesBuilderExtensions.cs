using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SendRequestAttributesBuilderExtensions
    {
        public static IDictionary<string, string> Create(this ISendRequestAttributesBuilder builder, string variableName, TimeSpan timeOut)
        {
            return builder.Mode(RequestMode.New)
                .ResponseVariable(variableName)
                .Timeout(timeOut)
                .IgnoreError(false)
                .Create();
        }
    }
}