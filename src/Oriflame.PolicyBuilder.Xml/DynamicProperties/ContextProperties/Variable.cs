using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Provides value set in context variable
    /// </summary>
    public class Variable : ContextProperty, IVariable
    {
        public Variable(string path) : base(path)
        {
        }

        public string AsString() => $"((string){GetPropertyPath()})";

        public IResponse AsResponse() => new Response($"((IResponse){GetPropertyPath()})");

        public string AsBoolean() => $"((bool){GetPropertyPath()})";

        public string AsJObject() => $"((JObject){GetPropertyPath()})";
    }
}
