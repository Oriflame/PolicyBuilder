using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Operation : ContextProperty, IOperation
    {
        public Operation(string path) : base(path)
        {
        }

        public string Id => GetPropertyPath(nameof(Id));

        public string Method => GetPropertyPath(nameof(Method));

        public string Name => GetPropertyPath(nameof(Name));

        public string UrlTemplate => GetPropertyPath(nameof(UrlTemplate));
    }
}