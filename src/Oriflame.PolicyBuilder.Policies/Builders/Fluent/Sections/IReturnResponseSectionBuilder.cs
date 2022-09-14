using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Actions;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections
{
    public interface IReturnResponseSectionBuilder : ISetHeaders<IReturnResponseSectionBuilder>, ISetStatus<IReturnResponseSectionBuilder>, IPolicySectionBuilder
    {
        IReturnResponseSectionBuilder SetBody(ILiquidTemplate template);

        IReturnResponseSectionBuilder SetBody(string value);
    }
}