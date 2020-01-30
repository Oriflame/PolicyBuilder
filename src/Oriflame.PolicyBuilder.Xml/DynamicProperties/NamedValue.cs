namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public static class NamedValue
    {
        public static string Get(string name)
        {
            return $"{{{{{name}}}}}";
        }
    }
}