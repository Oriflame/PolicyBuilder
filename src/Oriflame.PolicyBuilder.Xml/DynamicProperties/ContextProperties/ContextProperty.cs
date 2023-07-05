namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public abstract class ContextProperty
    {
        protected readonly string _path;

        protected ContextProperty(string path)
        {
            _path = path;
        }

        public string Get()
        {
            return ToString();
        }

        public override string ToString()
        {
            return _path;
        }
    }
}
