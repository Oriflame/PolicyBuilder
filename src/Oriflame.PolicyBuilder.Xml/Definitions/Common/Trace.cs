using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class Trace : PolicyXmlBase
    {
        private readonly string _content;

        public Trace(string sourceName, string content, Severity? severity = null) : base("trace")
        {
            _content = content;
            Attributes.Add("source", sourceName);
            if (severity != null)
            {
                Attributes.Add("severity", severity.ToString().ToLower());
            }
        }

        public override XNode GetXml()
        {
            return CreateElement(_content);
        }
    }
}