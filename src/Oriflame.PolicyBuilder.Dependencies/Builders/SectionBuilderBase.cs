using System;
using System.Collections.Generic;
using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public abstract class SectionBuilderBase<TSection> : IPolicySectionBuilder<TSection>
        where TSection : class, IPolicySectionBuilder
    {
        protected readonly DependenciesPolicy OperationPolicy;

        protected SectionBuilderBase(DependenciesPolicy operationPolicy)
        {
            OperationPolicy = operationPolicy;
        }

        public TSection SendRequest(Func<ISendRequestAttributesBuilder, IDictionary<string, string>> sendRequestAttributesBuilder, Func<ISendRequestSectionBuilder, ISectionPolicy> sendRequestBuilder)
        {
            var policy = sendRequestBuilder.Invoke(new SendRequestSectionBuilder());
            OperationPolicy.Add(policy as IDependency);
            return Return();
        }

        public TSection SetHeader(string name, string value = null, ExistsAction? existsAction = null)
        {
            return Return();
        }

        public TSection SetMethod(HttpMethod httpMethod)
        {
            OperationPolicy.Primary.SetMethod(httpMethod.Method);
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#set-variable"/>
        public TSection SetVariable(string name, string value)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#GetFromCacheByKey"/>
        public TSection CacheLookupValue(string key, string variable)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-caching-policies#StoreToCacheByKey"/>
        public TSection CacheStoreValue(string key, string value, TimeSpan duration)
        {
            return Return();
        }

        public ISectionPolicy Create()
        {
            return OperationPolicy;
        }

        public virtual TSection Base()
        {
            return Return();
        }

        public TSection Comment(string comment)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#ReturnResponse"/>
        public ISectionPolicy ReturnResponse(Func<IReturnResponseSectionBuilder, ISectionPolicy> returnResponseBuilder)
        {
            return OperationPolicy;
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Trace"/>
        public TSection Trace(string sourceName, string content)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#choose"/>
        public virtual TSection Choose(Func<IConditionSectionBuilder<TSection>, ISectionPolicy> conditionBuilder)
        {
            return Return();
        }
        private TSection Return()
        {
            return this as TSection;
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetBackendService"/>
        public TSection SetBackendService(string url)
        {
            OperationPolicy.Primary.SetDestination(url);
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
        public TSection SetQueryParameter(string name, string value, ExistsAction? skip)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetBody"/>
        public TSection SetBody(string value)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/cs-cz/azure/api-management/api-management-transformation-policies#SetBody"/>
        public TSection SetBody(ILiquidTemplate template)
        {
            return Return();
        }

        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#Retry"/>
        public TSection Retry(string condition, int count, TimeSpan interval, Func<TSection, ISectionPolicy> action,
            bool? firstFastRetry = null)
        {
            return Return();
        }
    }
}