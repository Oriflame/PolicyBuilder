using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Body : ContextProperty
    {
        public Body(string parentPath) : base($"{parentPath}.{nameof(Body)}")
        {
        }

        public string GetAsJObject(bool preserveContent = false)
        {
            return $"{this}.As<JObject>({GetPreserveContentParameter(preserveContent)})";
        }

        public string GetAsString(bool preserveContent = false)
        {
            return $"{this}.As<string>({GetPreserveContentParameter(preserveContent)})";
        }

        public string GetAsJArray(bool preserveContent = false)
        {
            return $"{this}.As<JArray>({GetPreserveContentParameter(preserveContent)})";
        }

        private string GetPreserveContentParameter(bool preserveContent)
        {
            return preserveContent ? @$"{nameof(preserveContent)}: {BoolMapper.Map(preserveContent)}" : string.Empty;
        }
    }
}
