namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class LastError : ContextProperty
    {
        public LastError(string path) : base(path)
        {
        }

        public string Source => $"{Get()}.{nameof(Source)}";

        public string Reason => $"{Get()}.{nameof(Reason)}";

        public string Message => $"{Get()}.{nameof(Message)}";

        public string Scope => $"{Get()}.{nameof(Scope)}";

        public string Section => $"{Get()}.{nameof(Section)}";

        public string Path => $"{Get()}.{nameof(Path)}";

        public string PolicyId => $"{Get()}.{nameof(PolicyId)}";
    }
}