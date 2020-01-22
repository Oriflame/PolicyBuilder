namespace Oriflame.PolicyBuilder.Dependencies
{
    public interface IDependency
    {
        string Destination { get; }

        string Uri { get; }

        string Method { get; }

        void SetUri(string uri);

        void SetDestination(string destination);

        void SetMethod(string method);
    }
}
