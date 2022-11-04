using Oriflame.PolicyBuilder.Xml.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public static class ContextRequest
    {
        public static string Get(bool inline = false)
        {
            return "context.Request".ToPolicyCode(inline);
        }

        public static string GetBody(bool inline = false)
        {
            return $"{Get(true)}.Body".ToPolicyCode(inline);
        }

        public static string GetBodyAsJObject(bool inline = false, bool preserveContent = false)
        {
            return $"{GetBody(true)}.As<JObject>({GetPreserveContentParameter(preserveContent)})".ToPolicyCode(inline);
        }

        public static string GetBodyAsString(bool inline = false, bool preserveContent = false)
        {
            return $"{GetBody(true)}.As<string>({GetPreserveContentParameter(preserveContent)})".ToPolicyCode(inline);
        }
        
        public static string GetBodyAsJArray(bool inline = false, bool preserveContent = false)
        {
            return $"{GetBody(true)}.As<JArray>({GetPreserveContentParameter(preserveContent)})".ToPolicyCode(inline);
        }

        public static string GetRouteParam(string paramName, bool inline = false)
        {
            return $"{Get(true)}.MatchedParameters[\"{paramName}\"]".ToPolicyCode(inline);
        }

        public static string GetRouteParamAsString(string paramName, bool inline = false)
        {
            return $"(string){GetRouteParam(paramName, true)}".ToPolicyCode(inline);
        }

        public static string GetQueryParam(string paramName, string defaultValue, bool inline = false)
        {
            var command = defaultValue == null
                ? $"{Get(true)}.OriginalUrl.Query.GetValueOrDefault(\"{paramName}\")"
                : $"{Get(true)}.OriginalUrl.Query.GetValueOrDefault(\"{paramName}\", \"{defaultValue}\")";
            return command.ToPolicyCode(inline);
        }

        public static string GetHeaderParam(string paramName, string defaultValue, bool inline = false)
        {
            var command = defaultValue == null
                ? $"{Get(true)}.Headers.GetValueOrDefault(\"{paramName}\")"
                : $"{Get(true)}.Headers.GetValueOrDefault(\"{paramName}\", \"{defaultValue}\")";
            return command.ToPolicyCode(inline);
        }

        private static string GetPreserveContentParameter(bool preserveContent)
        {
            return preserveContent ? @$"{nameof(preserveContent)}: {BoolMapper.Map(preserveContent)}" : string.Empty;
        }
    }
}