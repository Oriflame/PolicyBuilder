namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Dimention : PolicyXmlBase
    {
        public Dimention(string name, string value) : base("dimention")
        {
            Attributes.Add("name", name);
            Attributes.Add("value", value);
        }
    }
}
