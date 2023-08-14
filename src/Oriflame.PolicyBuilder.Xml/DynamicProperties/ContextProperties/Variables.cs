using System.Globalization;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Provides value set in context variable
    /// </summary>
    public class Variables : ReadonlyDictionaryWithDefaultContextProperty<IVariable>, IVariables
    {
        public Variables(string path) : base(path)
        {
        }

        protected override IVariable CreateInstance(string propertyPath)
        {
            return new Variable(propertyPath);
        }

        public string GetValueOrDefault<T>(string variableName, T defaultValue, bool explicitCast = false)
        {
            var policy = GetValueOrDefaultVariableCommand(variableName, defaultValue);
            if (explicitCast)
            {
                policy = $"(({typeof(T).FullName}){policy})";
            }

            return policy;
        }

        private string GetValueOrDefaultVariableCommand<T>(string variableName, T defaultValue)
        {
            var type = typeof(T);
            if (type == typeof(string))
            {
                return @$"{GetPropertyPath()}.GetValueOrDefault(""{variableName}"", ""{defaultValue}"")";
            }

            if (type == typeof(bool))
            {
                return @$"{GetPropertyPath()}.GetValueOrDefault(""{variableName}"", {defaultValue.ToString().ToLower()})";
            }

            return string.Format(CultureInfo.InvariantCulture, $@"{GetPropertyPath()}.GetValueOrDefault(""{{0}}"", {{1}})", variableName, defaultValue);
        }
    }
}
