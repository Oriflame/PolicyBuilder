﻿using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class MatchedParameters : ContextProperty, IMatchedParameters
    {
        public MatchedParameters(string path) : base(path)
        {
        }

        public string GetParam(string paramName)
        {
            return @$"{Get()}[""{paramName}""]";
        }

        public string GetParamAsString(string paramName)
        {
            return $"(string){GetParam(paramName)}";
        }

        // TODO props
    }
}