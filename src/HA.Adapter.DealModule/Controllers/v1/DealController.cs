using HA.Adapter.DealModule.Commands;
using HA.Adapter.DealModule.Queries;
using HA.Adapter.DealModule.ViewModel;
using HA.Application.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HA.Adapter.DealModule.Controllers.v1
{
    public class DealController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vm = await Mediator.Send(new GetAllDealsQuery());
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DealViewModel>> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetDealByIdQuery(id));
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DealViewModel>> Create([FromBody] CreateDealCommand command)
        {
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateDealCommand command)
        {
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteDealCommand(id));
            return NoContent();
        }
    }
}