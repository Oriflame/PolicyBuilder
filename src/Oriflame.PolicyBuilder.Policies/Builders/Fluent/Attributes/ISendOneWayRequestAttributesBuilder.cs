using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface ISendOneWayRequestAttributesBuilder : IAttributesBuilder
    {
        ISendOneWayRequestAttributesBuilder Mode(RequestMode mode);
    }
}