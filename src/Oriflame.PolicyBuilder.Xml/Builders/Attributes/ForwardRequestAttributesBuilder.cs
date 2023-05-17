using System;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes;

public class ForwardRequestAttributesBuilder : AttributesBuilderBase<IForwardRequestAttributesBuilder>, IForwardRequestAttributesBuilder
{
    private const string _timeout = "timeout";
    private const string _failOnErrorStatusCode = "fail-on-error-status-code";
    private const string _followRedirects = "follow-redirects";
    private const string _bufferRequestBody = "buffer-request-body";
    private const string _bufferResponse = "buffer-response";
    
    public IForwardRequestAttributesBuilder Timeout(TimeSpan timeout)
    {
        return AddAttribute(_timeout, timeout.GetSeconds());
    }
    
    public IForwardRequestAttributesBuilder Timeout(string value)
    {
        return AddAttribute(_timeout, value);
    }

    public IForwardRequestAttributesBuilder FailOnErrorStatusCode(bool value)
    {
        return AddAttribute(_failOnErrorStatusCode, value);
    }
    
    public IForwardRequestAttributesBuilder FailOnErrorStatusCode(string value)
    {
        return AddAttribute(_failOnErrorStatusCode, value);
    }

    public IForwardRequestAttributesBuilder FollowRedirects(bool value)
    {
        return AddAttribute(_followRedirects, value);
    }
    
    public IForwardRequestAttributesBuilder FollowRedirects(string value)
    {
        return AddAttribute(_followRedirects, value);
    }

    public IForwardRequestAttributesBuilder BufferRequestBody(bool value)
    {
        return AddAttribute(_bufferRequestBody, value);
    }
    
    public IForwardRequestAttributesBuilder BufferRequestBody(string value)
    {
        return AddAttribute(_bufferRequestBody, value);
    }

    public IForwardRequestAttributesBuilder BufferResponse(bool value)
    {
        return AddAttribute(_bufferResponse, value);
    }
    
    public IForwardRequestAttributesBuilder BufferResponse(string value)
    {
        return AddAttribute(_bufferResponse, value);
    }
}