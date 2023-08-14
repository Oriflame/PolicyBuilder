namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IBody : IContextProperty
    {
        string AsJArray(bool preserveContent = false);
        string AsJObject(bool preserveContent = false);
        string AsString(bool preserveContent = false);
    }
}