using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface ISendRequestAttributesBuilder : IAttributesBuilder
    {
        ISendRequestAttributesBuilder Mode(RequestMode mode);

        ISendRequestAttributesBuilder ResponseVariable(string variableName);

        ISendRequestAttributesBuilder Timeout(TimeSpan time);

        ISendRequestAttributesBuilder Timeout(string value);

        ISendRequestAttributesBuilder IgnoreError(bool value);
    }
}