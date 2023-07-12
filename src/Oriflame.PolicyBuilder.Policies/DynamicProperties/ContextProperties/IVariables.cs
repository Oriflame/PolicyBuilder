namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariables : IContextProperty
    {
        IVariable GetVariable(string variableName, bool strict = true);
        string Contains(string variableName);
        string GetValueOrDefault<T>(string variableName, T defaultValue, bool explicitCast = false);
    }
}