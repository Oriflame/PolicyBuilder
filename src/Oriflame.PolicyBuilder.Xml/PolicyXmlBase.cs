using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml
{
    public abstract class PolicyXmlBase : PolicyBase, IXmlPolicy
    {
        protected PolicyXmlBase(string elementName, IDictionary<string, string> attributes) : base(attributes)
        {
            XmlElementName = elementName;
        }

        protected PolicyXmlBase(string elementName) : this(elementName, null)
        {
            XmlElementName = elementName;
        }

        protected readonly string XmlElementName;


        public virtual XNode GetXml()
        {
            return CreateElement();
        }

        protected virtual XElement CreateElement(params object[] content)
        {
            var objects = new List<object> { content };
            objects.AddRange(GetXmlAttributes());
            return new XElement(XmlElementName, objects.ToArray());
        }

        private IEnumerable<XAttribute> GetXmlAttributes()
        {
            return Attributes.Select(a => new XAttribute(a.Key, NormalizeLineBreaks(a.Value)));
        }

        /// <summary>
        /// To be OS independent, lets normalize line breaks to \r\n.
        /// </summary>
        private static string NormalizeLineBreaks(string value)
        {
            if (value == null || !value.Contains('\n'))
            {
                return value;
            }

            var sb = new StringBuilder(value.Length);
            
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] == '\n' && (i == 0 || value[i - 1] != '\r'))
                {
                    sb.Append('\r');
                }
                sb.Append(value[i]);
            }

            return sb.ToString();
        }
    }
}