using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner.Cors
{
    public class AllowedMethods : PolicyXmlBase
    {
        private readonly IList<Method> _methods = new List<Method>();

        public AllowedMethods(int? preflightResultMaxAge = null) : this(null, preflightResultMaxAge)
        {
        }

        public AllowedMethods(HttpMethod[] methods, int? preflightResultMaxAge = null) : base("allowed-methods")
        {
            if (preflightResultMaxAge != null)
            {
                Attributes.Add("preflight-result-max-age", preflightResultMaxAge.ToString());
            }

            if (methods == null)
            {
                _methods.Add(new Method("*"));
            }
            else
            {
                foreach (var httpMethod in methods)
                {
                    _methods.Add(new Method(httpMethod.Method));
                }
            }
        }

        public override XNode GetXml()
        {
            return CreateElement(_methods.Select(o => (object)o.GetXml()).ToArray());
        }
    }
}