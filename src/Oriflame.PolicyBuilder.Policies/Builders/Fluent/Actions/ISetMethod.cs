using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
    public interface ISetMethod<T> where T : IPolicySectionBuilder
    {
        T SetMethod(HttpMethod httpMethod);
    }
}