namespace Oriflame.PolicyBuilder.Xml.Extensions
{
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