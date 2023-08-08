using System;
using Microsoft.AspNetCore.Mvc;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Extensions;
using Oriflame.PolicyBuilder.Policies.Expressions;
using Oriflame.PolicyBuilder.Xml.DynamicProperties;
using Oriflame.PolicyBuilder.Xml.Extensions;
using Oriflame.PolicyBuilder.Xml.Providers;

namespace Oriflame.PolicyBuilder.ApiExample.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPolicyBuilder _policyBuilder;

        public WeatherForecastController(IPolicyBuilder policyBuilder)
        {
            _policyBuilder = policyBuilder;
        }

        [HttpGet("{id}")]
        public string GetById()
        {
            return _policyBuilder
                    .Inbound(builder => builder
                        .Base()
                        .SetBackendService("https://contonso.com")
                        .RewriteUri("api/v1")
                        .Create()
                    )
                    .Backend(builder => builder
                        .Base()
                        .Create())
                    .Outbound(builder => builder
                        .Base()
                        .CacheStore(TimeSpan.FromSeconds(5))
                        .Create())
                    .OnError(builder => builder
                        .Base()
                        .Create())
                    .Return<string>();
        }

        [HttpGet]
        public string Get()
        {
            return _policyBuilder
                .Inbound(builder => builder
                    .Base()
                    .SetBackendAndRewriteUri("https://contonso.com", "api/v1")
                )
                .Backend()
                .OutboundWithCaching(TimeSpan.FromSeconds(5))
                .OnError()
                .Return<string>();
        }

        [HttpPost]
        public void Post(string forecast)
        {
            _policyBuilder.SetBackendAndRewriteUri("https://contonso.com", "api/v1");
        }

        [HttpPut]
        public void Put(string forecast)
        {
            var backendUrlVariableName = "backendUrl";
            _policyBuilder
                .Inbound(builder => builder
                    .Base()
                    .SetVariable(backendUrlVariableName, NamedValue.Get("Backend"))
                    .Create()
                )
                .Backend(builder => builder
                    .SetBackendService(new SingleStatementExpression(ContextProvider.Context.Variables.GetVariable(backendUrlVariableName).GetAsString()))
                    .Base()
                    .Create())
                .Outbound()
                .OnError();
        }
    }
}
