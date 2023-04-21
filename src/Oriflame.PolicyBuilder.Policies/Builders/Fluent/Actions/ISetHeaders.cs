using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    /// <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetHTTPheader"/>
    public interface ISetHeaders<T> where T : IPolicySectionBuilder
    {
        T DeleteHeader(string name);

        T SetHeader(string name, string value = null, ExistsAction? existsAction = null);
    }
}