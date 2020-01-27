using Oriflame.PolicyBuilder.Policies.DynamicProperties;

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
            return $"{(inline ? "" : "@")}((string){GetVariableCommand(variableName, strict)})";
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

        public static string GetAsJObject(string variableName, bool strict = true)
        {
            return $"((JObject){GetVariableCommand(variableName, strict)})";
        }

        public static string GetBodyAsString(string variableName, bool inline = false)
        {
            return $"({GetBodyCommand(variableName)}.As<string>())".ToPolicyCode(inline);
        }

        public static string GetBodyAsJObject(string variableName)
        {
            return $"({GetBodyCommand(variableName)}.As<JObject>())";
        }
       
        private static string GetVariableCommand(string variableName, bool strict = true)
        {
            return strict
                ? $"context.Variables[\"{variableName}\"]"
                : $"context.Variables.GetValueOrDefault(\"{variableName}\")";
        }

        private static string GetBodyCommand(string variableName)
        {
            return $"{GetAsResponse(variableName)}.Body";
        }

        public static string Contains(string variableName)
        {
            return $"context.Variables.ContainsKey(\"{variableName}\")";
        }
    }
}
