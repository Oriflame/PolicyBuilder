using System.Net.Http;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies.Builders
{
    public class SendRequestSectionBuilder : ISendRequestSectionBuilder
    {

        private Dependency _dependency;

        public SendRequestSectionBuilder()
        {
            _dependency = new Dependency();
        }

        public ISendRequestSectionBuilder SetHeader(string name, string value = null, ExistsAction? existsAction = null)
        {
            return this;
        }

        public ISendRequestSectionBuilder SetMethod(HttpMethod httpMethod)
        {
            _dependency.Method = httpMethod.Method;
            return this;
        }

        public ISectionPolicy Create()
        {
            return _dependency;
        }

        public ISendRequestSectionBuilder SetUrl(string url)
        {
            _dependency.SetUri(url);
            return this;
        }

        public ISendRequestSectionBuilder SetBody(string content)
        {
            return this;
        }
    }
}