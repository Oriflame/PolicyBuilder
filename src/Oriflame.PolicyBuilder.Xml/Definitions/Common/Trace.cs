using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class Trace : PolicyXmlBase
    {
        private readonly string _content;

        public Trace(string sourceName, string content) : base("trace")
        {
            _content = content;
            Attributes.Add("source", sourceName);
        }

        public override XNode GetXml()
        {
            return CreateElement(_content);
        }
    }
}