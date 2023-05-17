using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Xml.Definitions.Common;

namespace Oriflame.PolicyBuilder.Xml.Builders.Sections
{
    public partial class BackendSectionPolicyBuilder : SectionBuilderBase<IBackendSectionPolicyBuilder>, IBackendSectionPolicyBuilder
    {
        /// <inheritdoc />
        public IBackendSectionPolicyBuilder DeleteQueryParameter(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public virtual IBackendSectionPolicyBuilder SetQueryParameter(string name, string value, ExistsAction? existsAction)
        {
            return AddPolicyDefinition(new SetQueryParameter(name, value, existsAction));
        }
    }
}