using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Body : ContextProperty, IBody
    {
        public Body(string path) : base(path)
        {
        }

        public string AsJObject(bool preserveContent = false)
        {
            return $"{GetPropertyPath()}.As<JObject>({GetPreserveContentParameter(preserveContent)})";
        }

        public string AsString(bool preserveContent = false)
        {
            return $"{GetPropertyPath()}.As<string>({GetPreserveContentParameter(preserveContent)})";
        }

        public string AsJArray(bool preserveContent = false)
        {
            return $"{GetPropertyPath()}.As<JArray>({GetPreserveContentParameter(preserveContent)})";
        }

        private string GetPreserveContentParameter(bool preserveContent)
        {
            return preserveContent ? @$"{nameof(preserveContent)}: {BoolMapper.Map(preserveContent)}" : string.Empty;
        }
    }
}
