using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    /// <summary>
    /// Provides value from request header property
    /// </summary>
    public class RequestHeader : IRequestHeaderProperty
    {
        private readonly string _variableName;

        public RequestHeader(string variableName)
        {
            _variableName = variableName;
        }

        public string GetAsString()
        {
            return Get(_variableName);
        }

    
        public static string Get(string variableName, string defaultValue = null, bool inline = false)
        {
            if (inline)
            {
                return GetValueCommand(variableName, defaultValue);
            }

            return $"@({GetValueCommand(variableName, defaultValue)})";
        }

        private static string GetValueCommand(string variableName, string defaultValue)
        {
            if (defaultValue == null)
            {
                return $"context.Request.Headers.GetValueOrDefault(\"{variableName}\")";
            }

            return $"context.Request.Headers.GetValueOrDefault(\"{variableName}\", \"{defaultValue}\")";
        }
    }
}