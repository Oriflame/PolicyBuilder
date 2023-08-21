using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class UserIdentities : ContextProperty, IUserIdentities
    {
        public UserIdentities(string path) : base(path)
        {
        }
    }
}
