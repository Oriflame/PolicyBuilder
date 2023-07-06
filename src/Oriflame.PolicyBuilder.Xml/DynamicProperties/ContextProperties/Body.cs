using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Body : ContextProperty, IBody
    {
        public Body(string path) : base(path)
        {
        }

        public string GetAsJObject(bool preserveContent = false)
        {
            return $"{Get()}.As<JObject>({GetPreserveContentParameter(preserveContent)})";
        }

        public string GetAsString(bool preserveContent = false)
        {
            return $"{Get()}.As<string>({GetPreserveContentParameter(preserveContent)})";
        }

        public string GetAsJArray(bool preserveContent = false)
        {
            return $"{Get()}.As<JArray>({GetPreserveContentParameter(preserveContent)})";
        }

        private string GetPreserveContentParameter(bool preserveContent)
        {
            return preserveContent ? @$"{nameof(preserveContent)}: {BoolMapper.Map(preserveContent)}" : string.Empty;
        }
    }
}
