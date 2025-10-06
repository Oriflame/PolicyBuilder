using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Original type is derived from <see cref="System.Collections.Generic.IReadOnlyDictionary{string, string[]}"/>
    /// </summary>
    public class Query : ReadonlyDictionaryWithDefaultContextProperty<IQueryParam>, IQuery
    {
        public Query(string path) : base(path)
        {
        }

        protected override IQueryParam CreateInstance(string propertyPath)
        {
            return new QueryParam(propertyPath);
        }
    }
}
