using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class AuthenticationCertificate : PolicyXmlBase
    {
        public AuthenticationCertificate(string thumbprint) : base("authentication-certificate")
        {
            Attributes.Add("thumbprint", thumbprint);
        }

        public override XNode GetXml()
        {
            return CreateElement();
        }
    }
}