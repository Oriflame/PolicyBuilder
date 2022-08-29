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

            return $@"@({code})";
        }
    }
}