using System;
using System.Collections.Generic;
using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IInboundSectionPolicyBuilder : IPolicySectionBuilder<IInboundSectionPolicyBuilder>
    {
        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#RewriteURL"/>
        IInboundSectionPolicyBuilder RewriteUri(string uriTemplate);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetBackendService"/>
        IInboundSectionPolicyBuilder SetBackendService(string url);

        /// <see cref="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        IInboundSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? skip);

        /// <see cref="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetBody"/>
        IInboundSectionPolicyBuilder SetBody(ILiquidTemplate template);

        /// <see cref="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetBody"/>
        IInboundSectionPolicyBuilder SetBody(string value);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#mock-response" />
        ISectionPolicy MockResponse(HttpStatusCode? statusCode = null, string contentType = null);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-access-restriction-policies#ValidateJWT"/>
        IInboundSectionPolicyBuilder ValidateJwt(Func<IJwtValidationAttributesBuilder, IDictionary<string, string>> jwtAttributesBuilder, string openIdConfigUrl = null, IEnumerable<string> issuers = null);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        IInboundSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action, bool? firstFastRetry = null);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-cross-domain-policies#CORS"/>
        IInboundSectionPolicyBuilder Cors(Func<ICorsPolicyBuilder, ISectionPolicy> corsBuilder);

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies"/>
        IInboundSectionPolicyBuilder CacheLookup(Func<ICacheLookupAttributesBuilder, IDictionary<string, string>> cachingAttributesBuilder, Func<ICacheLookupSectionBuilder, ISectionPolicy> cachingSectionPolicyBuilder = null);
    }
}