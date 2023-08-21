namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IRequest : IContextProperty
    {
        IBody Body { get; }
        string Certificate { get; }
        IHeaders Headers { get; }
        string IpAddress { get; }
        IMatchedParameters MatchedParameters { get; }
        string Method { get; }
        IUrl OriginalUrl { get; }
        IUrl Url { get; }
    }
}