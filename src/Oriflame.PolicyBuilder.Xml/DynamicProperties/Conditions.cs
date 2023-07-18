﻿using System;
using Oriflame.PolicyBuilder.Xml.Providers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public static class Conditions
    {
        public static string IsNullOrEmpty(string variableName, bool strict = true)
        {
            return GetIsNullOrEmptyCommand(variableName, strict);
        }

        public static string IsNull(string variableName, bool strict = true)
        {
            return GetNullCommand(false, variableName, strict);
        }

        public static string IsNotNull(string variableName, bool strict = true)
        {
            return GetNullCommand(true, variableName, strict);
        }

        public static string IsRequestBodyNull()
        {
            return $"string.IsNullOrEmpty({ContextProvider.Context.Request.Body.GetAsString(true)})";
        }

        public static string IsResponseCodeOk(string variableName = null, bool strict = true)
        {
            return ResponseCodeOkCheckCommand(false, variableName, strict);
        }

        public static string IsResponseCodeNotOk(string variableName = null, bool strict = true)
        {
            return ResponseCodeOkCheckCommand(true, variableName, strict);
        }

        public static string IsResponseNull(string variableName = null, bool strict = true)
        {
            return ResponseNullCheckCommand(false, variableName, strict);
        }

        public static string IsResponseNotNull(string variableName = null, bool strict = true)
        {
            return ResponseNullCheckCommand(true, variableName, strict);
        }

        private static string ResponseNullCheckCommand(bool negative, string variableName = null, bool strict = true)
        {
            return GetNullCommand(negative, variableName, strict, VariableType.Response);
        }

        private static string ResponseCodeOkCheckCommand(bool negative, string variableName = null, bool strict = true)
        {
            return GetOkCommand(negative, variableName, strict, VariableType.Response);
        }

        private static string GetIsNullOrEmptyCommand(string variableName, bool strict)
        {
            return $"(string.IsNullOrEmpty{ContextProvider.Context.Variables.GetVariable(variableName, strict).GetAsString()})";
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
                return ContextProvider.Context.Variables.GetVariable(variableName, strict).GetAsResponse().Get();
            }

            switch (type)
            {
                case VariableType.Request:
                    return ContextProvider.Context.Request.Body.Get();
                case VariableType.Response:
                    return ContextProvider.Context.Response.Get();
                case VariableType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string GetVariableIdentifier(string variableName, bool strict, VariableType type)
        {
            if (variableName != null)
            {
                return ContextProvider.Context.Variables.GetVariable(variableName, strict).Get();
            }

            switch (type)
            {
                case VariableType.Request:
                    return ContextProvider.Context.Request.Body.Get();
                case VariableType.Response:
                    return ContextProvider.Context.Response.Get();
                case VariableType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private enum VariableType
        {
            Undefined,
            Request,
            Response
        }
    }
}