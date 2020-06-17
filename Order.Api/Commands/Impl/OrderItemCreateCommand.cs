namespace Order.Api.Commands.Impl
{
    public class OrderItemCreateCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
