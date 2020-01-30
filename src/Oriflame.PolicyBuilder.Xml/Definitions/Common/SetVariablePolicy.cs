namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetVariablePolicy : PolicyXmlBase
    {
        public SetVariablePolicy(string name, string value) : base("set-variable")
        {
            Attributes.Add("name", name);
            Attributes.Add("value", value);
        }
    }
}