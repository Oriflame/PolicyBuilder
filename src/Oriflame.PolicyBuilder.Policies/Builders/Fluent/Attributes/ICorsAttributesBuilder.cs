namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface ICorsAttributesBuilder : IAttributesBuilder
    {
        /// <summary>
        /// The Access-Control-Allow-Credentials header in the preflight response will be set to the value of this attribute and affect the client's ability to submit credentials in cross-domain requests.
        /// </summary>
        ICorsAttributesBuilder AllowCredentials(bool value);

        /// <summary>
        /// This attribute controls the processing of cross-origin requests that don't match the CORS policy settings. When OPTIONS request is processed as a pre-flight request and doesn't match CORS policy settings: If the attribute is set to true, immediately terminate the request with an empty 200 OK response; If the attribute is set to false, check inbound for other in-scope CORS policies that are direct children of the inbound element and apply them. If no CORS policies are found, terminate the request with an empty 200 OK response. When GET or HEAD request includes the Origin header (and therefore is processed as a cross-origin request) and doesn't match CORS policy settings: If the attribute is set to true, immediately terminate the request with an empty 200 OK response; If the attribute is set to false, allow the request to proceed normally and don't add CORS headers to the response.
        /// </summary>
        ICorsAttributesBuilder TerminateUnmatchedRequest(bool value);
    }
}