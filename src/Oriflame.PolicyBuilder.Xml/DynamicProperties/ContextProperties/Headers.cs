namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Headers : ContextProperty
    {
        public Headers(string path) : base(path)
        {
        }

        public string GetParam(string paramName, string defaultValue)
        {
            var command = defaultValue == null
                ? $"{Get()}.GetValueOrDefault(\"{paramName}\")"
                : $"{Get()}.GetValueOrDefault(\"{paramName}\", \"{defaultValue}\")";
            return command;
        }

        // TODO props
    }
}
