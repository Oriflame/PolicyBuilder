using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Query : ReadonlyDictionaryWithDefaultContextProperty<IQueryParam>, IQuery
    {
        /// <summary>
        /// Type: <see cref="IReadOnlyDictionary{string, string[]}"/>
        /// </summary>
        /// <param name="path"></param>
        public Query(string path) : base(path)
        {
        }

        protected override IQueryParam CreateInstance(string propertyPath)
        {
            return new QueryParam(propertyPath);
        }
    }
}
