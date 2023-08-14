namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariable : IContextProperty
    {
        IBody Body { get; }

        string AsBoolean();

        string AsJObject();

        IResponse AsResponse();

        string AsString();
    }
}