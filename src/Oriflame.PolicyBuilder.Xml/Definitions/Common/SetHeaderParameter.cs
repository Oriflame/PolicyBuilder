using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetHeaderParameter : PolicyXmlBase
    {
        private readonly Value _value;

        public SetHeaderParameter(string name, string value, ExistsAction? existsAction) : base("set-header")
        {
            if (value != null)
            {
                _value = new Value(value);
            }
            Attributes.Add("name", name);
            Attributes.Add("exists-action", ExistsActionMapper.Map(existsAction));
        }

        public override XNode GetXml()
        {
            return _value == null ? CreateElement() : CreateElement(_value.GetXml());
        }
    }
}