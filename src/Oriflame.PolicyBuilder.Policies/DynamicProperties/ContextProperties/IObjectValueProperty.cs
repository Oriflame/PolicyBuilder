namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IObjectValueProperty
    {
        string AsInt();

        string AsString();

        string AsBoolean();

        string AsJObject();

        IResponse AsResponse();
    }
}