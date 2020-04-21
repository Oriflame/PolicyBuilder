using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Policy.Cors;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders
{
    public class CorsPolicyBuilder : ICorsPolicyBuilder, IAllowedOriginsPolicyBuilder, IAllowedMethodsPolicyBuilder, IAllowedHeadersPolicyBuilder, IExposeHeadersPolicyBuilder
    {
        private AllowedOrigins _allowedOrigins;

        private AllowedMethods _allowedMethods;

        private AllowedHeaders _allowedHeaders;

        private ExposeHeaders _exposedHeaders;

        private int? _preflightResultMaxAge;

        public virtual IAllowedMethodsPolicyBuilder AllOrigins()
        {
            _allowedOrigins = new AllowedOrigins();
            return this;
        }

        public virtual IAllowedMethodsPolicyBuilder Origins(params string[] origins)
        {
            _allowedOrigins = new AllowedOrigins(origins);
            return this;
        }

        public virtual IAllowedMethodsPolicyBuilder PreflightResultMaxAge(int seconds)
        {
            _preflightResultMaxAge = seconds;
            return this;
        }

        public virtual IAllowedHeadersPolicyBuilder AllMethods()
        {
            _allowedMethods = new AllowedMethods(_preflightResultMaxAge);
            return this;
        }

        public virtual IAllowedHeadersPolicyBuilder Methods(params HttpMethod[] methods)
        {
            _allowedMethods = new AllowedMethods(methods, _preflightResultMaxAge);
            return this;
        }

        public virtual IExposeHeadersPolicyBuilder AllHeaders()
        {
            _allowedHeaders = new AllowedHeaders();
            return this;
        }

        public virtual IExposeHeadersPolicyBuilder Headers(params string[] headers)
        {
            _allowedHeaders = new AllowedHeaders(headers);
            return this;
        }

        public virtual ISectionPolicy AllExposeHeaders()
        {
            _exposedHeaders = new ExposeHeaders();
            return Create();
        }

        public virtual ISectionPolicy ExposeHeaders(params string[] exposeHeaders)
        {
            _exposedHeaders = new ExposeHeaders(exposeHeaders);
            return Create();
        }

        public virtual ISectionPolicy Create()
        {
            var sectionPolicy = new SectionPolicy("cors");
            sectionPolicy.AddInnerPolicy(_allowedOrigins);
            sectionPolicy.AddInnerPolicy(_allowedMethods);
            sectionPolicy.AddInnerPolicy(_allowedHeaders);
            sectionPolicy.AddInnerPolicy(_exposedHeaders);
            return sectionPolicy;
        }
    }
}