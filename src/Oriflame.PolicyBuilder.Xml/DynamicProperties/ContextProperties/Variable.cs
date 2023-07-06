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
            Body = new Body($"((IResponse){Get()}).{nameof(Body)}");
        }

        public IBody Body { get; }

        public string GetAsString()
        {
            return $"((string){Get()})";
        }

        public string GetAsResponse()
        {
            return $"((IResponse){Get()})";
        }

        public string GetStatusCode()
        {
            return $"({GetAsResponse()}.StatusCode)";
        }

        public string GetStatusReason()
        {
            return $"({GetAsResponse()}.StatusReason)";
        }

        public string GetAsBoolean()
        {
            return $"((bool){Get()})";
        }

        public string GetAsJObject()
        {
            return $"((JObject){Get()})";
        }
    }
}
