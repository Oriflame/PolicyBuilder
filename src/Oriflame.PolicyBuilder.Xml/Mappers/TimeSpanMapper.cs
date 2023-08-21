using System;
using Oriflame.PolicyBuilder.Policies.Extensions;

namespace Oriflame.PolicyBuilder.Xml.Mappers
{
    public static class TimeSpanMapper
    {
        public static string MapSeconds(TimeSpan value)
        {
            return value.GetSeconds().ToString();
        }
    }
}
