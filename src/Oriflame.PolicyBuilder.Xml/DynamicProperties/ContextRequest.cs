namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public static class ContextRequest
    {
        public static string Get(bool inline = false)
        {
            return "context.Request".ToPolicyCode(inline);
        }

        public static string GetBody(bool inline = false)
        {
            return $"{Get(true)}.Body".ToPolicyCode(inline);
        }

        public static string GetBodyAsJObject(bool inline = false)
        {
            return $"{GetBody(true)}.As<JObject>()".ToPolicyCode(inline);
        }

        public static string GetBodyAsString(bool inline = false)
        {
            return $"{GetBody(true)}.As<string>(true)".ToPolicyCode(inline);
        }

        public static string GetRouteParam(string paramName, bool inline = false)
        {
            return $"{Get(true)}.MatchedParameters[\"{paramName}\"]".ToPolicyCode(inline);
        }

        public static string GetRouteParamAsString(string paramName, bool inline = false)
        {
            return $"(string){GetRouteParam(paramName, true)}".ToPolicyCode(inline);
        }
    }

    public static class StringExtensions
    {
        public static string ToPolicyCode(this string code, bool inline)
        {
            if (inline || code.Length > 0 && code[0] == '@')
            {
                return code;
            }

            if (code.Length > 1 && code[0] == '(' && code[code.Length - 1] == ')')
            {
                return $@"@{code}";
            }

            return $@"@({code})";
        }
    }
}