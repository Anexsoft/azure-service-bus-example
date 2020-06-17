using System.Collections.Generic;

namespace Order.Api.Commands.Impl
{
    public class OrderCreateCommand : ICommand
    {
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemCreateCommand> Items { get; set; }
    }
}
