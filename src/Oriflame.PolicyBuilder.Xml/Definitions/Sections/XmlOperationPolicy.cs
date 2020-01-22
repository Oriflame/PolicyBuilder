using System;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Xml.Definitions.Sections
{
    public class XmlOperationPolicy : PolicyXmlBase, IOperationPolicy
    {
        public SectionPolicy InboundPolicy { get; }

        public SectionPolicy BackendPolicy { get; }

        public SectionPolicy OutboundPolicy { get; }

        public SectionPolicy OnErrorPolicy { get; }

        private XNode _customDefinition;

        public void UseCustomDefinition(XNode xml)
        {
            _customDefinition = xml;
        }

        /// <summary>
        /// Allows you to transform Policy object to another object with specific policy representation  
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public TResult TransformTo<TResult>() where TResult : class
        {
            if (!(this is TResult))
            {
                throw new NotImplementedException();
            }
            
            return this as TResult;
        }

        public XmlOperationPolicy() : base("policies")
        {
            InboundPolicy = new SectionPolicy("inbound");
            BackendPolicy = new SectionPolicy("backend");
            OutboundPolicy = new SectionPolicy("outbound");
            OnErrorPolicy = new SectionPolicy("on-error");
        }

        public override XNode GetXml()
        {
            return _customDefinition ?? CreateElement(
                       InboundPolicy.GetXml(),
                       BackendPolicy.GetXml(),
                       OutboundPolicy.GetXml(),
                       OnErrorPolicy.GetXml());
        }
    }
}