using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public abstract class ContextProperty : IContextProperty
    {
        private readonly string _path;

        protected ContextProperty(string path)
        {
            _path = path;
        }

        public string Get()
        {
            return _path;
        }

        public override string ToString()
        {
            return Get();
        }
    }
}
