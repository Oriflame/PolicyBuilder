using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class SendOneWayRequestAttributesBuilder : AttributesBuilderBase<ISendOneWayRequestAttributesBuilder>, ISendOneWayRequestAttributesBuilder
    {
        public ISendOneWayRequestAttributesBuilder Mode(RequestMode mode)
        {
            return AddAttribute("mode", RequestModeMapper.Map(mode));
        }
    }
}