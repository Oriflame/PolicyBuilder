using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface ISendRequestSectionBuilder : ISetHeaders<ISendRequestSectionBuilder>, ISetMethod<ISendRequestSectionBuilder>, IPolicySectionBuilder
    {
        ISendRequestSectionBuilder SetUrl(string url);

        ISendRequestSectionBuilder SetBody(string content);

        ISendRequestSectionBuilder AuthenticationCertificate(string thumbprint);
    }
}