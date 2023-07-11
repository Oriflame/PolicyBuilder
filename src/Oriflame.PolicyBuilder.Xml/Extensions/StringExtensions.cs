using System;

namespace Oriflame.PolicyBuilder.Xml.Extensions
{
    public static class StringExtensions
    {
        public static string AsExpression(this string code)
        {
            if (IsExpression(code))
            {
                return code;
            }

            return $@"@({code})";
        }

        public static string AsExpression(this string code, bool multistatement)
        {
            if (IsExpression(code))
            {
                return code;
            }

            if (multistatement)
            {
                return $@"@{{{code}}}";
            }

            return AsExpression(code);
        }

        [Obsolete($"Please use {nameof(AsExpression)}")]
        public static string ToPolicyCode(this string code, bool inline = false)
        {
            if (inline || IsExpression(code))
            {
                return code;
            }

            return $@"@({code})";
        }

        public static string Cast(this string code, Type type)
        {
            return $"(({type.FullName}){code})";
        }

        private static bool IsExpression(string code)
        {
            return code.Length > 0 && code[0] == '@';
        }
    }
}