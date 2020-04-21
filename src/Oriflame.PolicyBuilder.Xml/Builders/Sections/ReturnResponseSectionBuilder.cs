using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;
using Oriflame.PolicyBuilder.Xml.Definitions.Inner;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public class ReturnResponseSectionBuilder : SectionBuilderBase<IReturnResponseSectionBuilder>, IReturnResponseSectionBuilder
    {
        public ReturnResponseSectionBuilder() : base(new SectionPolicy("return-response"))
        {
        }

        public virtual IReturnResponseSectionBuilder SetStatus(string httpStatusCode, string reason)
        {
            return AddPolicyDefinition(new SetStatus(httpStatusCode, reason));
        }

        public virtual IReturnResponseSectionBuilder SetBody(string value)
        {
            return AddPolicyDefinition(new SetBody(value));
        }
    }
}