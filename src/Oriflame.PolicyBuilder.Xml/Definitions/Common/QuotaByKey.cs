namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    /// <summary>
    /// Documentation <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-sample-flexible-throttling"/>
    /// </summary>
    public class QuotaByKey : PolicyXmlBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calls">Number of call limit for period</param>
        /// <param name="bandwidth">Bandwidth rate in kilobytes</param>
        /// <param name="renewalPeriod">Renewal period in seconds</param>
        /// <param name="counterKey">Counter key</param>
        public QuotaByKey(int calls, int bandwidth, int renewalPeriod, string counterKey)
            : this(calls.ToString(), bandwidth.ToString(), renewalPeriod.ToString(), counterKey)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calls">Number of call limit for period</param>
        /// <param name="bandwidth">Bandwidth rate in kilobytes</param>
        /// <param name="renewalPeriod">Renewal period in seconds</param>
        /// <param name="counterKey">Counter key</param>
        public QuotaByKey(string calls, string bandwidth, string renewalPeriod, string counterKey) : base("quota-by-key")
        {
            Attributes.Add("calls", calls);
            Attributes.Add("bandwidth", bandwidth);
            Attributes.Add("renewal-period", renewalPeriod);
            Attributes.Add("counter-key", counterKey);
        }
    }
}
