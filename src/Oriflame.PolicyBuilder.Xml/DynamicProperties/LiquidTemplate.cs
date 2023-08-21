using Oriflame.PolicyBuilder.Policies.DynamicProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties
{
    public class LiquidTemplate : ILiquidTemplate
    {
        private readonly string _content;

        public LiquidTemplate(string content)
        {
            _content = content;
        }

        public string AsString()
        {
            return _content;
        }
    }
}