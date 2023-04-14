using System;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    /// <summary>
    /// Provides value set in context variable
    /// </summary>
    public class ContextVariable : IDynamicProperty
    {
        private readonly string _variableName;

        public ContextVariable(string variableName)
        {
            _variableName = variableName;
        }

        public static string Get(string variableName, bool strict = true)
        {
            return GetVariableCommand(variableName, strict);
        }

        public static string GetValueOrDefault<T>(string variableName, T defaultValue, bool explicitCast = false)
        {
            var policy = GetValueOrDefaultVariableCommand(variableName, defaultValue);
            if (explicitCast)
            {
                return policy.Cast(typeof(T));
            }

            return policy;
        }

        public static string GetBody(string variableName)
        {
            return GetBodyCommand(variableName);
        }

        public string GetAsString()
        {
            return GetAsString(_variableName);
        }

        public static string GetAsString(string variableName, bool strict = true, bool inline = false)
        {
            return $"((string){GetVariableCommand(variableName, strict)})".ToPolicyCode(inline);
        }

        public static string GetValueOrDefaultAsString(string variableName, string defaultValue, bool inline = false)
        {
            return $"((string){GetValueOrDefaultVariableCommand(variableName, defaultValue)})".ToPolicyCode(inline);
        }

        public static string GetAsResponse(string variableName, bool strict = true)
        {
            return $"((IResponse){GetVariableCommand(variableName, strict)})";
        }

        public static string GetStatusCode(string variableName, bool inline = false)
        {
            return $"({GetAsResponse(variableName)}.StatusCode)".ToPolicyCode(inline);
        }

        public static string GetStatusReason(string variableName, bool inline = false)
        {
            return $"({GetAsResponse(variableName)}.StatusReason)".ToPolicyCode(inline);
        }

        public static string GetAsBoolean(string variableName, bool strict = true, bool inline = false)
        {
            return $"((bool){GetVariableCommand(variableName, strict)})".ToPolicyCode(inline);
        }

        public static string GetValueOrDefaultAsBoolean(string variableName, bool defaultValue, bool inline = false)
        {
            return $"((bool){GetValueOrDefaultVariableCommand(variableName, defaultValue)})".ToPolicyCode(inline);
        }

        public static string GetAsJObject(string variableName, bool strict = true)
        {
            return $"((JObject){GetVariableCommand(variableName, strict)})";
        }

        public static string GetBodyAsString(string variableName, bool inline = false, bool preserveContent = false)
        {
            return $"({GetBodyCommand(variableName)}.As<string>({GetPreserveContentParameter(preserveContent)}))".ToPolicyCode(inline);
        }

        public static string GetBodyAsJObject(string variableName, bool preserveContent = false)
        {
            return $"({GetBodyCommand(variableName)}.As<JObject>({GetPreserveContentParameter(preserveContent)}))";
        }

        public static string Contains(string variableName)
        {
            return $"context.Variables.ContainsKey(\"{variableName}\")";
        }

        private static string GetVariableCommand(string variableName, bool strict = true)
        {
            return strict
                ? $"context.Variables[\"{variableName}\"]"
                : GetValueOrDefaultVariableCommand<string>(variableName, default);
        }

        private static string GetValueOrDefaultVariableCommand<T>(string variableName, T defaultValue = default)
        {
            var type = typeof(T);
            if (object.Equals(defaultValue, default(T)))
            {
                return @$"context.Variables.GetValueOrDefault(""{variableName}"")";
            }

            if (type == typeof(string))
            {
                return @$"context.Variables.GetValueOrDefault(""{variableName}"", ""{defaultValue}"")";
            }

            if (type == typeof(bool))
            {
                return @$"context.Variables.GetValueOrDefault(""{variableName}"", {defaultValue.ToString().ToLower()})";
            }

            return string.Format(CultureInfo.InvariantCulture, @"context.Variables.GetValueOrDefault(""{0}"", {1})", variableName, defaultValue); ;
        }

        private static string GetBodyCommand(string variableName)
        {
            return $"{GetAsResponse(variableName)}.Body";
        }

        private static string GetPreserveContentParameter(bool preserveContent)
        {
            return preserveContent ? @$"{nameof(preserveContent)}: {BoolMapper.Map(preserveContent)}" : string.Empty;
        }

        private static bool ImplementsInterface(Type type1, Type type2)
        {
            return type1.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == type2);
        }
    }
}
