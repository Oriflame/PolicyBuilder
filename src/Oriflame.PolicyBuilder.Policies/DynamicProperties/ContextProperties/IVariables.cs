namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariables : IContextProperty
    {
        IVariable this[string variableName] { get; }
        IVariable this[string variableName, bool strict] { get; }

        string Contains(string variableName);
        string GetValueOrDefault<T>(string variableName, T defaultValue, bool explicitCast = false);
    }
}