using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetQueryParameter : PolicyXmlBase
    {
        private readonly Value _value;

        public SetQueryParameter(string name, ExistsAction existsAction) : this(name, null, existsAction)
        {
        }

        public SetQueryParameter(string name, string value, ExistsAction? existsAction) : base("set-query-parameter")
        {
            if (existsAction == ExistsAction.Delete)
            {
                if (value != null)
                {
                    throw new System.ArgumentException("Parameter marked for deletion cannot have value(s) specified.");
                }
            }
            else
            {
                _value = new Value(value);
            }

            Attributes.Add("name", name);
            Attributes.Add("exists-action", ExistsActionMapper.Map(existsAction));
        }

        public override XNode GetXml()
        {
            if (_value != null)
            {
                return CreateElement(_value.GetXml());
            }

            return CreateElement();
        }
    }
}