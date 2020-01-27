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

        public IAllowedMethodsPolicyBuilder AllOrigins()
        {
            _allowedOrigins = new AllowedOrigins();
            return this;
        }

        public IAllowedMethodsPolicyBuilder Origins(params string[] origins)
        {
            _allowedOrigins = new AllowedOrigins(origins);
            return this;
        }

        public IAllowedMethodsPolicyBuilder PreflightResultMaxAge(int seconds)
        {
            _preflightResultMaxAge = seconds;
            return this;
        }

        public IAllowedHeadersPolicyBuilder AllMethods()
        {
            _allowedMethods = new AllowedMethods(_preflightResultMaxAge);
            return this;
        }

        public IAllowedHeadersPolicyBuilder Methods(params HttpMethod[] methods)
        {
            _allowedMethods = new AllowedMethods(methods, _preflightResultMaxAge);
            return this;
        }

        public IExposeHeadersPolicyBuilder AllHeaders()
        {
            _allowedHeaders = new AllowedHeaders();
            return this;
        }

        public IExposeHeadersPolicyBuilder Headers(params string[] headers)
        {
            _allowedHeaders = new AllowedHeaders(headers);
            return this;
        }

        public ISectionPolicy AllExposeHeaders()
        {
            _exposedHeaders = new ExposeHeaders();
            return Create();
        }

        public ISectionPolicy ExposeHeaders(params string[] exposeHeaders)
        {
            _exposedHeaders = new ExposeHeaders(exposeHeaders);
            return Create();
        }

        public ISectionPolicy Create()
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