using System;
using System.Collections.Generic;
using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class InboundSectionPolicyBuilder : SectionBuilderBase<IInboundSectionPolicyBuilder>, IInboundSectionPolicyBuilder
    {
        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder RewriteUri(string uriTemplate)
        {
            return AddPolicyDefinition(new RewriteUriPolicy(uriTemplate));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetBackendService(string url)
        {
            return AddPolicyDefinition(new SetBackendService(url));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? skip)
        {
            return AddPolicyDefinition(new SetQueryParameter(name, value, skip));
        }

        public virtual IInboundSectionPolicyBuilder SetBody(ILiquidTemplate template)
        {
            return AddPolicyDefinition(new SetBodyLiquid(template));
        }

        /// <inheritdoc />
        public virtual IInboundSectionPolicyBuilder SetBody(string value)
        {
            return AddPolicyDefinition(new SetBody(value));
        }

        /// <inheritdoc />
        public virtual ISectionPolicy MockResponse(HttpStatusCode? statusCode = null, string contentType = null)
        {
            AddPolicyDefinition(new MockResponse(statusCode, contentType));
            return Create();
        }

        /// <inheritdoc />
        public override IInboundSectionPolicyBuilder Choose(Func<IConditionSectionBuilder<IInboundSectionPolicyBuilder>, ISectionPolicy> conditionBuilder)
        {
            var conditionSectionBuilder = new InboundConditionSectionBuilder();
            return AddPolicyDefinition(conditionBuilder.Invoke(conditionSectionBuilder));
        }

        /// <inheritdoc />
        public IInboundSectionPolicyBuilder ValidateJwt(Func<IJwtValidationAttributesBuilder, IDictionary<string, string>> jwtAttributesBuilder, string openIdConfigUrl = null,
            IEnumerable<string> issuers = null, Func<IRequiredClaimsSectionBuilder, ISectionPolicy> requiredClaimsBuilder = null)
        {
            var attributesBuilder = new JwtAttributesBuilder();
            var attributes = jwtAttributesBuilder.Invoke(attributesBuilder);
            var requiredClaimsSectionBuilder = new RequiredClaimsSectionBuilder();
            var requiredClaims = requiredClaimsBuilder?.Invoke(requiredClaimsSectionBuilder);
            var policy = new JwtValidationPolicy(attributes, openIdConfigUrl, issuers, requiredClaims);
            return AddPolicyDefinition(policy);
        }

        /// <inheritdoc />
        public IInboundSectionPolicyBuilder Retry(string condition, int count, TimeSpan interval, Func<IInboundSectionPolicyBuilder, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            var actionBuilder = new InboundSectionPolicyBuilder(new RetryPolicy(condition, count, interval, firstFastRetry));
            return AddPolicyDefinition(action.Invoke(actionBuilder));
        }

        public IInboundSectionPolicyBuilder Cors(Func<ICorsPolicyBuilder, ISectionPolicy> corsBuilder)
        {
            var corsPolicyBuilder = new CorsPolicyBuilder();
            return AddPolicyDefinition(corsBuilder.Invoke(corsPolicyBuilder));
        }

        /// <inheritdoc />
        public IInboundSectionPolicyBuilder CacheLookup(Func<ICacheLookupAttributesBuilder, IDictionary<string, string>> cachingAttributesBuilder,
            Func<ICacheLookupSectionBuilder, ISectionPolicy> cachingSectionPolicyBuilder = null)
        {
            if (cachingSectionPolicyBuilder == null)
            {
                cachingSectionPolicyBuilder = new Func<ICacheLookupSectionBuilder, ISectionPolicy>(x => x.Create());
            }
            var attributesBuilder = new CacheLookupAttributesBuilder();
            var attributes = cachingAttributesBuilder.Invoke(attributesBuilder);
            var policyBuilder = new CacheLookupSectionBuilder(attributes);
            return AddPolicyDefinition(cachingSectionPolicyBuilder.Invoke(policyBuilder));
        }

        public InboundSectionPolicyBuilder(ISectionPolicy sectionPolicy) : base(sectionPolicy)
        {
        }
    }
}