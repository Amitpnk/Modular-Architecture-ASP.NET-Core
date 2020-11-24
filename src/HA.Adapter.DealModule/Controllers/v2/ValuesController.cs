using HA.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HA.Adapter.DealModule.Controllers.v2
{
    [ApiVersion("2")]
    public class ValuesController : BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}
