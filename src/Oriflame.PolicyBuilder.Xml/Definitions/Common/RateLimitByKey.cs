namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    /// <summary>
    /// Documentation <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-sample-flexible-throttling"/>
    /// </summary>
    public class RateLimitByKey : PolicyXmlBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calls">Number of call limit for period</param>
        /// <param name="renewalPeriod">Renewal period in seconds</param>
        /// <param name="counterKey">Counter key</param>
        public RateLimitByKey(int calls, int renewalPeriod, string counterKey)
            : this(calls.ToString(), renewalPeriod.ToString(), counterKey)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calls">Number of call limit for period</param>
        /// <param name="renewalPeriod">Renewal period in seconds</param>
        /// <param name="counterKey">Counter key</param>
        public RateLimitByKey(string calls, string renewalPeriod, string counterKey) : base("rate-limit-by-key")
        {
            Attributes.Add("calls", calls.ToString());
            Attributes.Add("renewal-period", renewalPeriod.ToString());
            Attributes.Add("counter-key", counterKey);
        }
    }
}
