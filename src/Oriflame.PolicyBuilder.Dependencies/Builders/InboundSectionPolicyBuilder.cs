using System;
using System.Collections.Generic;
using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        public InboundSectionPolicyBuilder(DependenciesPolicy operationPolicy) : base(operationPolicy)
        {
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#RewriteURL"/>
        public IInboundSectionPolicyBuilder RewriteUri(string uriTemplate)
        {
            OperationPolicy.Primary.SetUri(uriTemplate);
            return this;
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#mock-response" />
        public ISectionPolicy MockResponse(HttpStatusCode? statusCode = null, string contentType = null)
        {
            return Create();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-access-restriction-policies#ValidateJWT"/>
        public IInboundSectionPolicyBuilder ValidateJwt(Func<IJwtValidationAttributesBuilder, IDictionary<string, string>> jwtAttributesBuilder, string openIdConfigUrl = null,
            IEnumerable<string> issuers = null)
        {
            return this;
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-cross-domain-policies#CORS"/>
        public IInboundSectionPolicyBuilder Cors(Func<ICorsPolicyBuilder, ISectionPolicy> corsBuilder)
        {
            return this;
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies"/>
        public IInboundSectionPolicyBuilder CacheLookup(Func<ICacheLookupAttributesBuilder, IDictionary<string, string>> cachingAttributesBuilder)
        {
            return this;
        }

        /// <inheritdoc />
        public override IInboundSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IInboundSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new InboundConditionSectionBuilder(OperationPolicy);
            conditionBuilder.Invoke(conditionSectionBuilder);
            return this;
        }
    }
}