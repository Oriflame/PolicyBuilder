using System.Net.Mime;
using Microsoft.Net.Http.Headers;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;

namespace Oriflame.PolicyBuilder.Xml.Extensions
{
    public static class SetHeadersExtensions
    {
        public static T SetJsonContentTypeHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.ContentType, MediaTypeNames.Application.Json, ExistsAction.Override);
        }

        public static T SetXmlContentTypeHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.ContentType, MediaTypeNames.Text.Xml, ExistsAction.Override);
        }

        public static T SetAuthorizationHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.Authorization, RequestHeader.Get(HeaderNames.Authorization, ""), ExistsAction.Override);
        }

        public static T SetAcceptHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.Accept, MediaTypeNames.Application.Json, ExistsAction.Override);
        }
    }
}