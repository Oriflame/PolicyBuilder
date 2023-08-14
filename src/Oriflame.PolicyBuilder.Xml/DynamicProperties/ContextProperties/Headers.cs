using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Headers : ReadonlyDictionaryWithDefaultContextProperty<IHeader>, IHeaders
    {
        public Headers(string path) : base(path)
        {
        }

        protected override IHeader CreateInstance(string propertyPath)
        {
            return new Header(propertyPath);
        }

        // TODO props
    }
}
