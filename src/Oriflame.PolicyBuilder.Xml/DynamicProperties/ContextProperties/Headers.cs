namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Headers : ContextProperty
    {

        public Headers(string parentPath) : base($"{parentPath}.{nameof(Headers)}")
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
