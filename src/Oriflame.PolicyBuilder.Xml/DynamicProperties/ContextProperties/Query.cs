namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Query : ContextProperty
    {
        public Query(string parentPath) : base($"{parentPath}.{nameof(Query)}")
        {
        }

        public string GetParam(string paramName, string defaultValue)
        {
            var command = defaultValue == null
                ? $"{this}.GetValueOrDefault(\"{paramName}\")"
                : $"{this}.GetValueOrDefault(\"{paramName}\", \"{defaultValue}\")";
            return command;
        }

        // TODO props
    }
}
