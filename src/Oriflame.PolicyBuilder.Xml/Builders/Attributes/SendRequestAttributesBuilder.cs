using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Xml.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class SendRequestAttributesBuilder : AttributesBuilderBase<ISendRequestAttributesBuilder>, ISendRequestAttributesBuilder
    {
        public ISendRequestAttributesBuilder Mode(RequestMode mode)
        {
            return AddAttribute("mode", RequestModeMapper.Map(mode));
        }

        public ISendRequestAttributesBuilder ResponseVariable(string variableName)
        {
            return AddAttribute("response-variable-name", variableName);
        }

        public ISendRequestAttributesBuilder Timeout(TimeSpan time)
        {
            return AddAttribute("timeout", time.GetSeconds());
        }

        public ISendRequestAttributesBuilder IgnoreError(bool value)
        {
            return AddAttribute("ignore-error", value);
        }
    }
}