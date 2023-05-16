using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class ForwardRequest : PolicyXmlBase
    {
       
        public ForwardRequest(string timeoutValue, IDictionary<string, string> attributes = null) : base("forward-request", attributes)
        {
            if (!string.IsNullOrEmpty(timeoutValue))
            {
                Attributes.Add("timeout", timeoutValue);
            }
        }
    }
}