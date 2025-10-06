using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Gateway : ContextProperty, IGateway
    {
        public Gateway(string path) : base(path)
        {
        }

        public string Id => GetPropertyPath(nameof(Id));

        public string InstanceId => GetPropertyPath(nameof(InstanceId));

        /// <summary>
        /// Type: <see cref="bool"/>
        /// </summary>
        public string IsManaged => GetPropertyPath(nameof(IsManaged));
    }
}