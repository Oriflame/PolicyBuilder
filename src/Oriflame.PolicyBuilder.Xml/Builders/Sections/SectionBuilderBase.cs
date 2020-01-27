using System;
using System.Collections.Generic;
using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Builders.Attributes;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public abstract class SectionBuilderBase<TSection> : IPolicySectionBuilder<TSection> where TSection : class, IPolicySectionBuilder
    {
        protected readonly ISectionPolicy SectionPolicy;

        protected SectionBuilderBase(ISectionPolicy sectionPolicy)
        {
            SectionPolicy = sectionPolicy;
        }

        public ISectionPolicy Create()
        {
            return SectionPolicy;
        }

        public TSection Base()
        {
            return AddPolicyDefinition(new BasePolicy());
        }

        public TSection Comment(string comment)
        {
            return AddPolicyDefinition(new CommentPolicy(comment));
        }
        
        public TSection SetVariable(string name, string value)
        {
            return AddPolicyDefinition(new SetVariablePolicy(name, value));
        }

        /// <inheritdoc />
        public ISectionPolicy ReturnResponse(Func<IReturnResponseSectionBuilder, ISectionPolicy> returnResponseBuilder)
        {
            var returnRequestSectionBuilder = new ReturnResponseSectionBuilder();
            AddPolicyDefinition(returnResponseBuilder.Invoke(returnRequestSectionBuilder) as IXmlPolicy);
            return Create();
        }

        /// <inheritdoc />
        public TSection Trace(string sourceName, string content)
        {
            return AddPolicyDefinition(new Trace(sourceName, content));
        }

        /// <inheritdoc />
        public TSection CacheLookupValue(string key, string variable)
        {
            return AddPolicyDefinition(new CacheLookupValuePolicy(key, variable));
        }

        /// <inheritdoc />
        public TSection SendRequest(Func<ISendRequestAttributesBuilder, IDictionary<string, string>> sendRequestAttributesBuilder, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder)
        {
            var attributes = sendRequestAttributesBuilder.Invoke(new SendRequestAttributesBuilder());
            var sendRequestSectionBuilder = new SendRequestSectionBuilder(attributes);
            return AddPolicyDefinition(sendRequestBuilder.Invoke(sendRequestSectionBuilder));
        }

        /// <inheritdoc />
        public TSection CacheStoreValue(string key, string value, TimeSpan duration)
        {
            return AddPolicyDefinition(new CacheStoreValue(key, value, duration));
        }

        /// <inheritdoc />
        public virtual TSection Choose(Func<IConditionSectionBuilder<TSection>, ISectionPolicy> conditionBuilder)
        {
            throw new NotImplementedException();
        }

        protected TSection AddPolicyDefinition(IXmlPolicy policy)
        {
            SectionPolicy.AddInnerPolicy(policy);
            return Return();
        }

        protected TSection AddPolicyDefinition(ISectionPolicy policy)
        {
            SectionPolicy.AddInnerPolicy(policy as IXmlPolicy);
            return Return();
        }

        private TSection Return()
        {
            return this as TSection;
        }

        public TSection SetHeader(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetHeaderParameter(name, value, existsAction));
        }

        public TSection SetMethod(HttpMethod httpMethod)
        {
            return AddPolicyDefinition(new SetMethod(httpMethod));
        }
    }
}
