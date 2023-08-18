using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public abstract class ReadonlyDictionaryContextProperty<T> : ContextProperty, IBuilderReadOnlyDictionary<T>
    {
        protected ReadonlyDictionaryContextProperty(string path) : base(path)
        {
        }

        public string TryGetValue(string key, string outValue) => GetPropertyPath(@$"TryGetValue({key}, out {outValue})");

        public T Get(string paramName)
        {
            return CreateInstance(@$"{GetPropertyPath()}[""{paramName}""]");
        }

        public string Keys => GetPropertyPath(nameof(Keys));

        public string Values => GetPropertyPath(nameof(Values));

        public string Count => GetPropertyPath(nameof(Count));

        T IBuilderReadOnlyDictionary<T>.this[string key] => Get(key);

        public string ContainsKey(string key) => GetPropertyPath(@$"ContainsKey(""{key}"")");
        

        protected abstract T CreateInstance(string propertyPath);
    }
}
