﻿using System;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Policies.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class RetryPolicy : SectionPolicy
    {
        public RetryPolicy(Expression condition, int count, TimeSpan interval, bool? firstFastRetry = null)
            : this(condition, count.ToString(), interval.GetSeconds(), firstFastRetry)
        {
        }

        public RetryPolicy(Expression condition, string count, TimeSpan interval, bool? firstFastRetry = null)
            : this(condition, count, interval.GetSeconds(), firstFastRetry)
        {
        }

        public RetryPolicy(Expression condition, int count, string interval, bool? firstFastRetry = null)
            : this(condition, count.ToString(), interval, firstFastRetry)
        {
        }

        public RetryPolicy(Expression condition, int count, TimeSpan interval, string firstFastRetry)
            : base("retry")
        {
            Initialize(condition, count.ToString(), interval.GetSeconds(), firstFastRetry);
        }

        public RetryPolicy(Expression condition, string count, string interval, string firstFastRetry)
            : base("retry")
        {
            Initialize(condition, count.ToString(), interval, firstFastRetry);
        }

        public RetryPolicy(Expression condition, string count, string interval, bool? firstFastRetry = null)
            : base("retry")
        {
            Initialize(condition, count, interval,
                firstFastRetry.HasValue ? BoolMapper.Map(firstFastRetry.Value) : string.Empty);
        }

        private void Initialize(Expression condition, string count, string interval, string firstFastRetry)
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
