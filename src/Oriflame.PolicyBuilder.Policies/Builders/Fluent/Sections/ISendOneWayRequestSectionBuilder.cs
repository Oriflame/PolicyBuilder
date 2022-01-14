using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface ISendOneWayRequestSectionBuilder : ISetHeaders<ISendOneWayRequestSectionBuilder>, ISetMethod<ISendOneWayRequestSectionBuilder>, IPolicySectionBuilder
    {
        ISendOneWayRequestSectionBuilder SetUrl(string url);

        ISendOneWayRequestSectionBuilder SetBody(string content);

        ISendOneWayRequestSectionBuilder AuthenticationCertificate(string thumbprint);
    }
}