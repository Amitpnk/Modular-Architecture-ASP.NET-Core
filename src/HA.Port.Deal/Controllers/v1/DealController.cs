using HA.Application.Controllers;
using HA.Application.DealFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HA.Port.Deal.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DealController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vm = await Mediator.Send(new GetAllDealsQuery());
            return Ok(vm);
        }
    }
}
