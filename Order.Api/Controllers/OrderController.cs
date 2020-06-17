using Microsoft.AspNetCore.Mvc;
using Order.Api.Commands.Handlers;
using Order.Api.Commands.Impl;
using System.Threading.Tasks;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IHandler<OrderCreateCommand> _handler;

        public OrderController(IHandler<OrderCreateCommand> handler) 
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateCommand command) 
        {
            await _handler.Execute(command);

            return NoContent();
        }
    }
}
