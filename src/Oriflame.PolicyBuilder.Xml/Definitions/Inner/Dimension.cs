namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Dimension : PolicyXmlBase
    {
        public Dimension(string name, string value = null) : base("dimension")
        {
            Attributes.Add("name", name);

            if (!string.IsNullOrEmpty(value))
            {
                Attributes.Add("value", value);
            }
        }
    }
}
