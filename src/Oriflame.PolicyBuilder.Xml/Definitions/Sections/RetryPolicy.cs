using System;
using Oriflame.PolicyBuilder.Xml.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class RetryPolicy : SectionPolicy
    {
        public RetryPolicy(string condition, int count, TimeSpan interval, bool? firstFastRetry = null) : base("retry")
        {
            Attributes.Add("condition", condition);
            Attributes.Add("count", count.ToString());
            Attributes.Add("interval", interval.GetSeconds());
            if (firstFastRetry != null)
            {
                Attributes.Add("first-fast-retry", BoolMapper.Map(firstFastRetry.Value));
            }
        }
    }
}