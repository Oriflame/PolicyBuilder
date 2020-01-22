using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class CommentPolicy : PolicyXmlBase
    {
        private readonly string _comment;

        public CommentPolicy(string comment) : base(null)
        {
            _comment = comment;
        }

        public override XNode GetXml()
        {
            return new XComment($" {_comment} ");
        }
    }
}
