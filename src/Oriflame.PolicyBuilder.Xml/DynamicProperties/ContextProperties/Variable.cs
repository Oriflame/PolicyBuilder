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

        public string GetAsString() => $"((string){Get()})";

        public IResponse GetAsResponse() => new Response($"((IResponse){Get()})");

        public string GetAsBoolean() => $"((bool){Get()})";

        public string GetAsJObject() => $"((JObject){Get()})";
    }
}
