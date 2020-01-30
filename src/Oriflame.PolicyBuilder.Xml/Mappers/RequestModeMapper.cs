using System;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.Xml.Mappers
{
    public static class RequestModeMapper
    {
        public static string Map(RequestMode requestMode)
        {
            switch (requestMode)
            {
                case RequestMode.Copy:
                    return "copy";
                case RequestMode.New:
                    return "new";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}