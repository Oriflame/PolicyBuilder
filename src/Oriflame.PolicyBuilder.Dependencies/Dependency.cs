using System.Text.RegularExpressions;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies
{
    public class Dependency : IDependency, ISectionPolicy
    {
        public Dependency()
        {
        }

        const string VariablePattern = "^\\@\\(\\(string\\)context.Variables\\[\\\"(.*)\\\"]\\)$";
        
        public string Destination { get; private set; }

        public string Uri { get; private set; }

        public string Method { get; set; }
        
        public void SetUri(string uri)
        {
            if (uri.StartsWith("@"))
            {
                Uri = "{DynamicResolution}";
                return;
            }
            Uri = $"{uri.TrimStart('/')}";
        }

        public void SetDestination(string destination)
        {
            var variable = Regex.Match(destination, VariablePattern).Groups[1].Value;
            if (!string.IsNullOrEmpty(variable))
            {
                Destination = variable;
                return;
            }

            Destination = destination;
        }

        public void SetMethod(string method)
        {
            Method = method;
        }

        public void AddInnerPolicy(IPolicy policy)
        {
        }
    }
}