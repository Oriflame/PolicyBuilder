using System.Collections.Generic;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner.Trace;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class Trace : PolicyXmlBase
    {
        private readonly string _content;

        public Trace(string sourceName, string message, Severity? severity = null) : base("trace")
        {
            _content = message;
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