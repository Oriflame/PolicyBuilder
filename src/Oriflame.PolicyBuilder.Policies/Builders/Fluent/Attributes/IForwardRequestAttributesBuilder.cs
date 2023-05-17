using System;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

public interface IForwardRequestAttributesBuilder : IAttributesBuilder
{
    /// <summary>
    /// The amount of time in seconds to wait for the HTTP response headers to be returned by the backend service before a timeout error is raised
    /// </summary>
    IForwardRequestAttributesBuilder Timeout(TimeSpan timeout);
    
    /// <summary>
    /// When set to true, triggers on-error section for response codes in the range from 400 to 599 inclusive
    /// </summary>
    IForwardRequestAttributesBuilder FailOnErrorStatusCode(bool value);

    /// <summary>
    /// Specifies whether redirects from the backend service are followed by the gateway or returned to the caller.
    /// </summary>
    IForwardRequestAttributesBuilder FollowRedirects(bool value);

    /// <summary>
    /// When set to true, request is buffered and will be reused on retry.
    /// </summary>
    IForwardRequestAttributesBuilder BufferRequestBody(bool value);

    /// <summary>
    /// Affects processing of chunked responses. When set to false, each chunk received from the backend is immediately returned to the caller. When set to true, chunks are buffered (8 KB, unless end of stream is detected) and only then returned to the caller.
    /// </summary>
    IForwardRequestAttributesBuilder BufferResponse(bool value);
}