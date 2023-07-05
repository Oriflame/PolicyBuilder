using System.Globalization;
using Oriflame.PolicyBuilder.Xml.Extensions;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Provides value set in context variable
    /// </summary>
    public class Variables : ContextProperty
    {
        public Body Body(string variableName) => new Body(_path);

        public Variables(string parentPath) : base($"{parentPath}.{nameof(Variables)}")
        {
        }

        public string Contains(string variableName)
        {
            return $"{_path}.ContainsKey(\"{variableName}\")";
        }

        public Variable this[string variableName] => GetVariable(variableName, true);

        public Variable this[string variableName, bool strict] => GetVariable(variableName, strict);

        public string GetValueOrDefault<T>(string variableName, T defaultValue, bool explicitCast = false)
        {
            var policy = GetValueOrDefaultVariableCommand(variableName, defaultValue);
            if (explicitCast)
            {
                policy = policy.Cast(typeof(T));
            }

            return policy;
        }

        private string GetValueOrDefaultVariableCommand<T>(string variableName, T defaultValue)
        {
            var type = typeof(T);
            if (type == typeof(string))
            {
                return @$"{_path}.GetValueOrDefault(""{variableName}"", ""{defaultValue}"")";
            }

            if (type == typeof(bool))
            {
                return @$"{_path}.GetValueOrDefault(""{variableName}"", {defaultValue.ToString().ToLower()})";
            }

            return string.Format(CultureInfo.InvariantCulture, $@"{_path}.GetValueOrDefault(""{{0}}"", {{1}})", variableName, defaultValue);
        }

        private Variable GetVariable(string variableName, bool strict = true)
        {
            return strict
                ? new Variable($"{_path}[\"{variableName}\"]")
                : new Variable(@$"{_path}.GetValueOrDefault(""{variableName}"")");
        }
    }
}
