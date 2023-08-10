using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;
using Oriflame.PolicyBuilder.Xml.Enums.Priorities;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class ReturnResponseSectionBuilder : SectionBuilderBase<IReturnResponseSectionBuilder>, IReturnResponseSectionBuilder
    {
        public ReturnResponseSectionBuilder() : base(new SectionPolicy("return-response"))
        {
        }

        /// <inheritdoc />
        public virtual IReturnResponseSectionBuilder SetStatus(string httpStatusCode, string reason)
        {
            return AddPolicyDefinition(new SetStatus(httpStatusCode, reason), (int)ReturnResponsePriority.SetStatus);
        }

        /// <inheritdoc />
        public virtual IReturnResponseSectionBuilder SetBody(ILiquidTemplate template)
        {
            return AddPolicyDefinition(new SetBodyLiquid(template), (int)ReturnResponsePriority.SetBody);
        }

        public virtual IReturnResponseSectionBuilder SetHeader(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetHeader(name, value, existsAction), (int)ReturnResponsePriority.SetHeader);
        }

        /// <inheritdoc />
        public virtual IReturnResponseSectionBuilder SetBody(string value)
        {
            return AddPolicyDefinition(new SetBody(value), (int)ReturnResponsePriority.SetBody);
        }
    }
}