using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class ForwardRequest : PolicyXmlBase
    {
        public ForwardRequest(IDictionary<string, string> attributes) : base("forward-request", attributes)
        {
        }
    }
}