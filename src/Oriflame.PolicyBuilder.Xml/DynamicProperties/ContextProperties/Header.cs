using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Header : ContextProperty, IHeader
    {
        public Header(string path) : base(path)
        {
        }
    }
}
