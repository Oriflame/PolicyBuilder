namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class SetStatus : PolicyXmlBase
    {
        public SetStatus(string httpStatusCode, string reason) : base("set-status")
        {
            Attributes.Add("code", httpStatusCode);
            Attributes.Add("reason", reason);
        }
    }
}