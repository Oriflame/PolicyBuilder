namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class LimitConcurrency : SectionPolicy
    {
        public LimitConcurrency(string key, int maxCount) : this(key, maxCount.ToString())
        {
        }
        public LimitConcurrency(string key, string maxCount) : base("limit-concurrency")
        {
            Attributes.Add("key", key);
            Attributes.Add("max-count", maxCount);
        }
    }
}
