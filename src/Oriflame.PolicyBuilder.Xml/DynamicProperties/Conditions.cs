using System;
using Oriflame.PolicyBuilder.Xml.Extensions;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public static class Conditions
    {
        public static string IsNullOrEmpty(string variableName, bool inline = false, bool strict = true)
        {
            return GetIsNullOrEmptyCommand(variableName, strict).ToPolicyCode(inline);
        }

        public static string IsNull(string variableName, bool inline = false, bool strict = true)
        {
            return GetNullCommand(false, variableName, strict).ToPolicyCode(inline);
        }

        public static string IsNotNull(string variableName, bool inline = false, bool strict = true)
        {
            return GetNullCommand(true, variableName, strict).ToPolicyCode(inline);
        }

        public static string IsRequestBodyNull(bool inline = false)
        {
            return $"string.IsNullOrEmpty({ContextRequest.GetBodyAsString(true)})".ToPolicyCode(inline);
        }

        public static string IsResponseCodeOk(string variableName = null, bool inline = false, bool strict = true)
        {
            return ResponseCodeOkCheckCommand(false, variableName, inline, strict);
        }

        public static string IsResponseCodeNotOk(string variableName = null, bool inline = false, bool strict = true)
        {
            return ResponseCodeOkCheckCommand(true, variableName, inline, strict);
        }

        public static string IsResponseNull(string variableName = null, bool inline = false, bool strict = true)
        {
            return ResponseNullCheckCommand(false, variableName, inline, strict);
        }

        public static string IsResponseNotNull(string variableName = null, bool inline = false, bool strict = true)
        {
            return ResponseNullCheckCommand(true, variableName, inline, strict);
        }

        private static string RequestNullCheckCommand(bool negative, bool inline, bool strict)
        {
            return GetNullCommand(negative, strict: strict, type: VariableType.Request).ToPolicyCode(inline);
        }

        private static string ResponseNullCheckCommand(bool negative, string variableName = null, bool inline = false, bool strict = true)
        {
            return GetNullCommand(negative, variableName, strict, VariableType.Response).ToPolicyCode(inline);
        }

        private static string ResponseCodeOkCheckCommand(bool negative, string variableName = null, bool inline = false, bool strict = true)
        {
            return GetOkCommand(negative, variableName, strict, VariableType.Response).ToPolicyCode(inline);
        }

        private static string GetIsNullOrEmptyCommand(string variableName, bool strict)
        {
            return $"(string.IsNullOrEmpty{ContextVariable.GetAsString(variableName, strict, true)})";
        }

        private static string GetNullCommand(bool negative, string variableName = null, bool strict = true, VariableType type = VariableType.Undefined)
        {
            return $"({GetVariableIdentifier(variableName, strict, type)} {(negative ? "!=" : "==")} null)";
        }

        private static string GetOkCommand(bool negative, string variableName, bool strict, VariableType type)
        {
            return $"({(negative ? "!" : "")}{GetVariableResponseIdentifier(variableName, strict, type)}.StatusCode.ToString().StartsWith(\"2\"))";
        }

        private static string GetVariableResponseIdentifier(string variableName, bool strict, VariableType type)
        {
            if (variableName != null)
            {
                return ContextVariable.GetAsResponse(variableName, strict);
            }

            switch (type)
            {
                case VariableType.Request:
                    return ContextRequest.GetBody();
                case VariableType.Response:
                    return ContextResponse.Get(true);
                case VariableType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string GetVariableIdentifier(string variableName, bool strict, VariableType type)
        {
            if (variableName != null)
            {
                return ContextVariable.Get(variableName, strict);
            }

            switch (type)
            {
                case VariableType.Request:
                    return ContextRequest.GetBody(true);
                case VariableType.Response:
                    return ContextResponse.Get(true);
                case VariableType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private enum VariableType
        {
            Undefined, Request, Response
        }
    }
}