﻿using System.Net.Mime;
using Microsoft.Net.Http.Headers;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Providers;

namespace Oriflame.PolicyBuilder.Xml.Extensions
{
    public static class SetHeadersExtensions
    {
        private const string JsonMimeType = "application/json";

        public static T SetJsonContentTypeHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.ContentType, JsonMimeType, ExistsAction.Override);
        }

        public static T SetXmlContentTypeHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.ContentType, MediaTypeNames.Text.Xml, ExistsAction.Override);
        }

        public static T SetAuthorizationHeader<T>(this ISetHeaders<T> policyBuilder) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.Authorization, ContextProvider.Context.Request.Headers.GetValueOrDefault(HeaderNames.Authorization, "").ToString(), ExistsAction.Override);
        }

        public static T SetAcceptHeader<T>(this ISetHeaders<T> policyBuilder, string mimeType = JsonMimeType) where T : IPolicySectionBuilder
        {
            return policyBuilder.SetHeader(HeaderNames.Accept, mimeType, ExistsAction.Override);
        }
    }
}