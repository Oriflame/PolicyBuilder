using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner.Trace
{
    public class Message : PolicyXmlBase
    {
        private readonly string _message;
        public Message(string message) : base("message")
        {
            _message = message;
        }

        public override XNode GetXml()
        {
            return CreateElement(_message);
        }
    }
}