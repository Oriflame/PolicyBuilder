using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions
{
    public interface ISetVariable<out TSection> where TSection : IPolicySectionBuilder
    {
        /// <see cref="https://docs.microsoft.com/en-us/azure/api-management/api-management-advanced-policies#set-variable"/>
        TSection SetVariable(string name, string value);
    }
}