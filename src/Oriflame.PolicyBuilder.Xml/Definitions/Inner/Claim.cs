using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Inner
{
    public class Claim : PolicyXmlBase
    {
        //private readonly string _name;
        private readonly IEnumerable<Value> _values;
        //private readonly Match _match;
        //private readonly string _separator;

        private const string Name = "name";
        private const string Match = "match";
        private const string Separator = "separator";

        public Claim(string name, IEnumerable<string> values, Match match, string separator) : base("claim")
        {
            Attributes.Add(Name, name);
            Attributes.Add(Match, match.ToString());
            Attributes.Add(Separator, separator);
            _values = values.Select(v => new Value(v));
        }

        public override XNode GetXml()
        {
            return CreateElement(_values.Select(v => (object)v.GetXml()).ToArray());
        }
    }
}
