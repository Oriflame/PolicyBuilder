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

        public static string GetStatusCode(bool inline = false)
        {
            return $"{Get(true)}.StatusCode".ToPolicyCode(inline);
        }

        public static string GetStatusReason(bool inline = false)
        {
            return $"{Get(true)}.StatusReason".ToPolicyCode(inline);
        }

        private static string GetPreserveContentParameter(bool preserveContent)
        {
            return @$"{nameof(preserveContent)}: {BoolMapper.Map(preserveContent)}";
        }
    }
}