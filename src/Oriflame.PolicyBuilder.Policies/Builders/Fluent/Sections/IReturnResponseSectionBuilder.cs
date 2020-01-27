using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IReturnResponseSectionBuilder : ISetHeaders<IReturnResponseSectionBuilder>, ISetStatus<IReturnResponseSectionBuilder>, IPolicySectionBuilder
    {
       IReturnResponseSectionBuilder SetBody(string value);
    }
}