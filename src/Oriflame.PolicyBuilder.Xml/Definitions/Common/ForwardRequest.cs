using System;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class ForwardRequest : PolicyXmlBase
    {
        public ForwardRequest(TimeSpan? timeout) : this(timeout?.GetSeconds())
        {
        }

        public ForwardRequest(string timeoutValue) : base("forward-request")
        {
            if (!string.IsNullOrEmpty(timeoutValue))
            {
                Attributes.Add("timeout", timeoutValue);
            }
        }
    }
}