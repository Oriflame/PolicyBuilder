using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Extensions
{
    public static class SetStatusExtensions
    {
        public static T SetStatus<T>(this ISetStatus<T> builder, HttpStatusCode statusCode, string reason) where T : IPolicySectionBuilder
        {
            return builder.SetStatus(((int)statusCode).ToString(), reason);
        }

        public static T SetOkStatus<T>(this ISetStatus<T> builder, string reason = "OK") where T : IPolicySectionBuilder
        {
            return builder.SetStatus(HttpStatusCode.OK, reason);
        }

        public static T SetBadRequestStatus<T>(this ISetStatus<T> builder, string reason = "Bad request") where T : IPolicySectionBuilder
        {
            return builder.SetStatus(HttpStatusCode.BadRequest, reason);
        }
    }
}