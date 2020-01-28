using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;
using Oriflame.PolicyBuilder.Xml.Mappers;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public abstract class AttributesBuilderBase<TAttributesBuilder> : IAttributesBuilder where TAttributesBuilder : class, IAttributesBuilder
    {
        private readonly IDictionary<string, string> _attributes;

        protected AttributesBuilderBase()
        {
            _attributes = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Create()
        {
            return _attributes;
        }

        protected TAttributesBuilder AddAttribute(string name, string value)
        {
            _attributes[name] = value;
            return Return();
        }

        protected TAttributesBuilder AddAttribute(string name, int value)
        {
            return AddAttribute(name, value.ToString());
        }

        protected TAttributesBuilder AddAttribute(string name, bool value)
        {
            return AddAttribute(name, BoolMapper.Map(value));
        }

        private TAttributesBuilder Return()
        {
            return this as TAttributesBuilder;
        }
    }
}