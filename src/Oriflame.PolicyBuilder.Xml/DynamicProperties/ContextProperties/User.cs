namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class User : ContextProperty
    {
        public User(string parentPath) : base($"{parentPath}.{nameof(User)}")
        {
        }
    }
}