using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class QueryParam : ContextProperty, IQueryParam
    {
        public QueryParam(string path) : base(path)
        {
        }

        public string AsString()
        {
            return $"(string){GetPropertyPath()}";
        }
    }
}