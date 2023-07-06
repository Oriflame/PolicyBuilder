namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IBody : IContextProperty
    {
        string GetAsJArray(bool preserveContent = false);
        string GetAsJObject(bool preserveContent = false);
        string GetAsString(bool preserveContent = false);
    }
}