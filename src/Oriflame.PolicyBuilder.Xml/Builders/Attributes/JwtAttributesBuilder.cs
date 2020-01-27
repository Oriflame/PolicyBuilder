using System.Net;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes;

namespace Oriflame.PolicyBuilder.Xml.Builders.Attributes
{
    public class JwtAttributesBuilder : AttributesBuilderBase<IJwtValidationOptionalAttributesBuilder>, IJwtValidationAttributesBuilder, IJwtValidationOptionalAttributesBuilder
    {
        public IJwtValidationOptionalAttributesBuilder HeaderName(string name)
        {
            return AddAttribute("header-name", name);
        }

        public IJwtValidationOptionalAttributesBuilder FailedValidationStatusCode(HttpStatusCode code)
        {
            return AddAttribute("failed-validation-httpcode", ((int)code).ToString());
        }

        public IJwtValidationOptionalAttributesBuilder FailedValidationMessage(string message)
        {
            return AddAttribute("failed-validation-error-message", message);
        }
    }
}