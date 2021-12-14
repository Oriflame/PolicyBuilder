using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Common
{
    /// <summary>
    /// Documentation <see href="https://docs.microsoft.com/en-us/azure/api-management/api-management-sample-flexible-throttling"/>
    /// </summary>
    public class EmitMetricPolicy : PolicyXmlBase
    {
        private readonly SectionPolicy _dimentions;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        /// <param name="namespace">Namespace</param>
        /// <param name="dimentions">Dimentions</param>
        public EmitMetricPolicy(string name, string value, string @namespace, ISectionPolicy dimentions = null) : base("emit-metric")
        {
            Attributes.Add("name", name);
            Attributes.Add("value", value);
            Attributes.Add("namespace", @namespace);
            _dimentions = dimentions as SectionPolicy;
        }

        public override XNode GetXml()
        {
            return CreateElement(_dimentions?.GetXml());
        }
    }
}
