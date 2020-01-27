using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Oriflame.PolicyBuilder.ApiExample.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Ok";
        }

        [HttpGet("{id}")]

        public string Get(string id)
        {
            return "Ok";
        }
    }
}
