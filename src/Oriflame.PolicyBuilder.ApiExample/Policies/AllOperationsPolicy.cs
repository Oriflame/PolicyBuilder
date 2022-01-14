using System.Collections.Generic;
using System.Net;
using Microsoft.Net.Http.Headers;
using Oriflame.PolicyBuilder.Policies;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Enums;

namespace Oriflame.PolicyBuilder.ApiExample.Policies
{
    public class AllOperationsPolicy : AllOperationsPolicyBase
    {
        public AllOperationsPolicy(IPolicyBuilder policyBuilder) : base(policyBuilder)
        {
        }

        public override void Create()
        {
            PolicyBuilder
                .Inbound(builder => builder
                    .Base()
                    .ValidateJwt(jwtAttr => jwtAttr
                            .HeaderName(HeaderNames.Authorization)
                            .FailedValidationStatusCode(HttpStatusCode.Unauthorized)
                            .FailedValidationMessage("Unauthorized. Access token is missing or invalid.")
                            .Create(),
                        "http://contoso.com/.well-known/openid-configuration",
                        new List<string> { "http://contoso.com/" },
                        requiredClaimsBuilder => requiredClaimsBuilder
                            .SetClaimPolicy("scope", new[] { "forcast_api" }, RequiredClaimsMatch.All)
                            .Create()
                        )
                    .Create())
                .Backend(builder => builder
                    .Base()
                    .Create())
                .Outbound(builder => builder
                    .Base()
                    .Create()
                );
        }
    }
}
