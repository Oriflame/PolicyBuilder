using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes;

public class ForwardRequestAttributesBuilder : AttributesBuilderBase<IForwardRequestAttributesBuilder>, IForwardRequestAttributesBuilder
{
    public IForwardRequestAttributesBuilder FailOnErrorStatusCode(bool value)
    {
        return AddAttribute("fail-on-error-status-code", value);
    }

    public IForwardRequestAttributesBuilder FollowRedirects(bool value)
    {
        return AddAttribute("follow-redirects", value);
    }

    public IForwardRequestAttributesBuilder BufferRequestBody(bool value)
    {
        return AddAttribute("buffer-request-body", value);
    }

    public IForwardRequestAttributesBuilder BufferResponse(bool value)
    {
        return AddAttribute("buffer-response", value);
    }
}