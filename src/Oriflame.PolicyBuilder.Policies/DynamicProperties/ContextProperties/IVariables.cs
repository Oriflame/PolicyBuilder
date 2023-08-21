namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IVariables : IContextProperty, IBuilderReadOnlyDictionary<IVariable>, IGetWithDefault<IVariable>
    {
        IVariable Get(string variableName);

        /// <summary>
        /// Gets the variable value of given type or default value if variable is not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableName"></param>
        /// <param name="defaultValue"></param>
        /// <param name="explicitCast"></param>
        /// <returns></returns>
        IVariable GetValueOrDefault<T>(string variableName, T defaultValue, bool explicitCast = false);
    }
}