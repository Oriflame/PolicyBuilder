using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#SetStatus"/>
    public interface ISetStatus<T> where T : IPolicySectionBuilder
    {
        T SetStatus(string statusCode, string reason);
    }
}