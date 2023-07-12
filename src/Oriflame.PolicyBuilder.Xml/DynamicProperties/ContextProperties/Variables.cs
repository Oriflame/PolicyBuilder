using System.Globalization;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;
using Oriflame.PolicyBuilder.Xml.Extensions;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Provides value set in context variable
    /// </summary>
    public class Variables : ContextProperty, IVariables
    {
        public Variables(string path) : base(path)
        {
        }

        public string Contains(string variableName)
        {
            return @$"{Get()}.ContainsKey(""{variableName}"")";
        }

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
                return @$"{Get()}.GetValueOrDefault(""{variableName}"", ""{defaultValue}"")";
            }

            if (type == typeof(bool))
            {
                return @$"{Get()}.GetValueOrDefault(""{variableName}"", {defaultValue.ToString().ToLower()})";
            }

            return string.Format(CultureInfo.InvariantCulture, $@"{Get()}.GetValueOrDefault(""{{0}}"", {{1}})", variableName, defaultValue);
        }

        public IVariable GetVariable(string variableName, bool strict = true)
        {
            return strict
                ? new Variable(@$"{Get()}[""{variableName}""]")
                : new Variable(@$"{Get()}.GetValueOrDefault(""{variableName}"")");
        }
    }
}
