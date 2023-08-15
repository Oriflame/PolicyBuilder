namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariable : IContextProperty, IObjectValueProperty
    {
        IBody Body { get; }
    }
}