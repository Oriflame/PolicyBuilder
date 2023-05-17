using Oriflame.PolicyBuilder.Xml.Extensions;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public static class ContextResponse
    {
        private const string Context = "context.Response";

        public static string Get(bool inline = false)
        {
            return $"((IResponse){Context})".ToPolicyCode(inline);
        }

        public static string GetBodyAsJObject(bool inline = false, bool preserveContent = false)
        {
            return $"{Context}.Body.As<JObject>({ GetPreserveContentParameter(preserveContent) })".ToPolicyCode(inline);
        }

        public static string GetBodyAsString(bool inline = false, bool preserveContent = false)
        {
            return $"{Context}.Body.As<string>({ GetPreserveContentParameter(preserveContent) })".ToPolicyCode(inline);
        }
        
        public static string GetBodyAsJArray(bool inline = false, bool preserveContent = false)
        {
            return $"{Context}.Body.As<JArray>({ GetPreserveContentParameter(preserveContent) })".ToPolicyCode(inline);
        }

        public static string GetStatusCode(bool inline = false)
        {
            return $"{Get(true)}.StatusCode".ToPolicyCode(inline);
        }

        public static string GetStatusReason(bool inline = false)
        {
            return $"{Get(true)}.StatusReason".ToPolicyCode(inline);
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