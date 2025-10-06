using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Groups : ContextProperty, IGroups
    {
        /// <summary>
        /// Type: <see cref="IEnumerable{IGroup}"/>
        /// </summary>
        public Groups(string path) : base(path)
        {
        }

        // TODO props
    }
}
