using System;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class RetryPolicy : SectionPolicy
    {
        public RetryPolicy(Expression condition, int count, TimeSpan interval, bool? firstFastRetry = null)
            : base("retry")
        {
            Initialize(condition, count.ToString(), TimeSpanMapper.MapSeconds(interval), BoolMapper.Map(firstFastRetry));
        }

        public RetryPolicy(Expression condition, Expression count, TimeSpan interval, bool? firstFastRetry = null)
            : base("retry")
        {
            Initialize(condition, count.ToString(), TimeSpanMapper.MapSeconds(interval), BoolMapper.Map(firstFastRetry));
        }

        public RetryPolicy(Expression condition, int count, Expression interval, bool? firstFastRetry = null)
             : base("retry")
        {
            Initialize(condition, count.ToString(), interval, BoolMapper.Map(firstFastRetry));
        }

        public RetryPolicy(Expression condition, int count, TimeSpan interval, Expression firstFastRetry)
            : base("retry")
        {
            Initialize(condition, count.ToString(), TimeSpanMapper.MapSeconds(interval), firstFastRetry);
        }

        public RetryPolicy(Expression condition, Expression count, Expression interval, bool? firstFastRetry = null)
            : base("retry")
        {
            Initialize(condition, count, interval, BoolMapper.Map(firstFastRetry));
        }

        public RetryPolicy(Expression condition, Expression count, Expression interval, Expression firstFastRetry)
            : base("retry")
        {
            Initialize(condition, count.ToString(), interval, firstFastRetry);
        }

        private void Initialize(string condition, string count, string interval, string firstFastRetry)
        {
            Attributes.Add("condition", condition);
            Attributes.Add("count", count);
            Attributes.Add("interval", interval);
            if (!string.IsNullOrEmpty(firstFastRetry))
            {
                Attributes.Add("first-fast-retry", firstFastRetry);
            }
        }
    }
}
