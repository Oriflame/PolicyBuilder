using System;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class ForwardRequest : PolicyXmlBase
    {
        public ForwardRequest(TimeSpan? timeout) : this(timeout?.GetSeconds())
        {
        }
        
        public ForwardRequest(string timeoutValue, bool? bufferResponse = null) : base("forward-request")
        {
            if (!string.IsNullOrEmpty(timeoutValue))
            {
                Attributes.Add("timeout", timeoutValue);
            }

            if (bufferResponse.HasValue)
            {
                Attributes.Add("buffer-response", BoolMapper.Map(bufferResponse.Value));
            }
        }
    }
}