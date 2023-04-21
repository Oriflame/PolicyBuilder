using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    public class SetHeader : PolicyXmlBase
    {
        private readonly Value _value;

        public SetHeader(string name, string value, ExistsAction? existsAction) : base("set-header")
        {
#pragma warning disable CS0618 // Type or member is obsolete
            if (existsAction == ExistsAction.Delete && value != null)
            {
                throw new System.ArgumentException("Parameter marked for deletion cannot have value(s) specified.");
            }
#pragma warning restore CS0618 // Type or member is obsolete

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