using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml
{
    public interface IXmlPolicy : IPolicy
    {
        XNode GetXml();
    }
}