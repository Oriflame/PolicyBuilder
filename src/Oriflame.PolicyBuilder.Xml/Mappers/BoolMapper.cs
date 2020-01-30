namespace Oriflame.PolicyBuilder.Xml.Mappers
{
    public static class BoolMapper
    {
        public static string Map(bool value)
        {
            return value ? "true" : "false";
        }
    }
}