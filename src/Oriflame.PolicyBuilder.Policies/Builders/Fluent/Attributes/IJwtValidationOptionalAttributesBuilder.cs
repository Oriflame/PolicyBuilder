using System.Net;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface IJwtValidationOptionalAttributesBuilder : IAttributesBuilder
    {
        IJwtValidationOptionalAttributesBuilder FailedValidationStatusCode(HttpStatusCode code);

        IJwtValidationOptionalAttributesBuilder FailedValidationMessage(string message);

        IJwtValidationOptionalAttributesBuilder RequireScheme(string scheme);

        IJwtValidationOptionalAttributesBuilder OutputTokenVariable(string variableName);
    }
}