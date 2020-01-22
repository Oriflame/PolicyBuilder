namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CacheLookupValuePolicy : PolicyXmlBase
    {
        public CacheLookupValuePolicy(string key, string variable) : base("cache-lookup-value")
        {
            Attributes.Add("key", key);
            Attributes.Add("variable-name", variable);
        }
    }
}