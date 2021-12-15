namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Dimension : PolicyXmlBase
    {
        public Dimension(string name, string value) : base("dimension")
        {
            Attributes.Add("name", name);
            Attributes.Add("value", value);
        }
    }
}
