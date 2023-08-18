using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public abstract class ReadonlyDictionaryWithDefaultContextProperty<T> : ReadonlyDictionaryContextProperty<T>, IGetWithDefault<T>
    {
        protected ReadonlyDictionaryWithDefaultContextProperty(string path) : base(path)
        {
        }

        public T GetValueOrDefault(string paramName, string defaultValue = null)
        {
            var propertyPath = defaultValue == null
                ? GetPropertyPath($"GetValueOrDefault(\"{paramName}\")")
                : GetPropertyPath($"GetValueOrDefault(\"{paramName}\", \"{defaultValue}\")");
            return CreateInstance(propertyPath);
        }
    }
}
