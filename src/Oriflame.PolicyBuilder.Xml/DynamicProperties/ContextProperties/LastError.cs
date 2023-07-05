namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class LastError : ContextProperty
    {
        private readonly string _path;
        
        public LastError(string parentPath) : base($"{parentPath}.{nameof(LastError)}")
        {
        }

        // TODO props
    }
}