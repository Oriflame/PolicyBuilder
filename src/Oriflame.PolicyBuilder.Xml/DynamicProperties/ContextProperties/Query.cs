using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Query : ContextProperty, IQuery
    {
        /// <summary>
        /// Type: <see cref="IReadOnlyDictionary{string, string[]}"/>
        /// </summary>
        /// <param name="path"></param>
        public Query(string path) : base(path)
        {
        }

        public string GetParam(string paramName, string defaultValue = null)
        {
            var command = defaultValue == null
                ? $"{Get()}.GetValueOrDefault(\"{paramName}\")"
                : $"{Get()}.GetValueOrDefault(\"{paramName}\", \"{defaultValue}\")";
            return command;
        }

        // TODO props
    }
}
