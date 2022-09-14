using System.Collections.Generic;
using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class CorsPolicySectionBuilder : SectionBuilderBase<ICorsPolicySectionBuilder>, ICorsPolicySectionBuilder, IAllowedOriginsPolicyBuilder, IAllowedMethodsPolicyBuilder, IAllowedHeadersPolicyBuilder, IExposeHeadersPolicyBuilder
    {
       private int? _preflightResultMaxAge;

        public CorsPolicySectionBuilder(IDictionary<string, string> attributes) : base(new SectionPolicy("cors", attributes))
        {
        }

        public virtual IAllowedMethodsPolicyBuilder AllOrigins()
        {
            AddPolicyDefinition(new AllowedOrigins());
            return this;
        }

        public virtual IAllowedMethodsPolicyBuilder Origins(params string[] origins)
        {
            AddPolicyDefinition(new AllowedOrigins(origins));
            return this;
        }

        public virtual IAllowedMethodsPolicyBuilder PreflightResultMaxAge(int seconds)
        {
            _preflightResultMaxAge = seconds;
            return this;
        }

        public virtual IAllowedHeadersPolicyBuilder AllMethods()
        {
            AddPolicyDefinition(new AllowedMethods(_preflightResultMaxAge));
            return this;
        }

        public virtual IAllowedHeadersPolicyBuilder Methods(params HttpMethod[] methods)
        {
            AddPolicyDefinition(new AllowedMethods(methods, _preflightResultMaxAge));
            return this;
        }

        public virtual IExposeHeadersPolicyBuilder AllHeaders()
        {
            AddPolicyDefinition(new AllowedHeaders());
            return this;
        }

        public virtual IExposeHeadersPolicyBuilder Headers(params string[] headers)
        {
            AddPolicyDefinition(new AllowedHeaders(headers));
            return this;
        }

        public virtual ISectionPolicy AllExposeHeaders()
        {
            AddPolicyDefinition(new ExposeHeaders());
            return Create();
        }

        public virtual ISectionPolicy ExposeHeaders(params string[] exposeHeaders)
        {
            AddPolicyDefinition(new ExposeHeaders(exposeHeaders));
            return Create();
        }
    }
}