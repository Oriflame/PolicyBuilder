namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariable : IContextProperty
    {
        IBody Body { get; }

        string GetAsBoolean();
        string GetAsJObject();
        IResponse AsResponse();
        string GetAsString();
    }
}