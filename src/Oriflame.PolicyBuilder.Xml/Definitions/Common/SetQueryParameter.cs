using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetQueryParameter : PolicyXmlBase
    {
        private readonly Value _value;

        public SetQueryParameter(string name, string value, ExistsAction? existsAction) : base("set-query-parameter")
        {
            _value = new Value(value);
            Attributes.Add("name", name);
            Attributes.Add("exists-action", ExistsActionMapper.Map(existsAction));
        }

        public override XNode GetXml()
        {
            return CreateElement( _value.GetXml());
        }
    }
}