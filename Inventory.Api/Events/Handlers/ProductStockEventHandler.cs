using Inventory.Api.Events.Impl;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Api.Events.Handlers
{
    public class ProductStockEventHandler : IHandler<IEnumerable<ProductStockEvent>>
    {
        public async Task Execute(IEnumerable<ProductStockEvent> @event)
        {
            // Do something awesome with your event
        }
    }
}
