using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class LastError : ContextProperty, ILastError
    {
        public LastError(string path) : base(path)
        {
        }

        public string Source => GetPropertyPath(nameof(Source));

        public string Reason => GetPropertyPath(nameof(Reason));

        public string Message => GetPropertyPath(nameof(Message));

        public string Scope => GetPropertyPath(nameof(Scope));

        public string Section => GetPropertyPath(nameof(Section));

        public string Path => GetPropertyPath(nameof(Path));

        public string PolicyId => GetPropertyPath(nameof(PolicyId));
    }
}