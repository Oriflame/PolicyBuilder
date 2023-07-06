namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariable : IContextProperty
    {
        IBody Body { get; }

        string GetAsBoolean();
        string GetAsJObject();
        string GetAsResponse();
        string GetAsString();
        string GetStatusCode();
        string GetStatusReason();
    }
}