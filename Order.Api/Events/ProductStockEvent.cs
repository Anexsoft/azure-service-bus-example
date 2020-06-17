namespace Order.Api.Events
{
    public class ProductStockEvent
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
