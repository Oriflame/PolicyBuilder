using System;

namespace Oriflame.PolicyBuilder.Xml.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string GetSeconds(this TimeSpan duration)
        {
            return Convert.ToInt32(duration.TotalSeconds).ToString();
        }
    }
}