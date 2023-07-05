namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    /// <summary>
    /// Provides value set in context variable
    /// </summary>
    public class Variable : ContextProperty
    {
        public Body Body => new Body($"((IResponse){_path})");

        public Variable(string path) : base(path)
        {
        }

        public string GetAsString()
        {
            return $"((string){_path})";
        }

        public string GetAsResponse()
        {
            return $"((IResponse){_path})";
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
            return $"((bool){_path})";
        }

        public string GetAsJObject()
        {
            return $"((JObject){_path})";
        }
    }
}
