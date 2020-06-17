namespace Inventory.Api.Events.Impl
{
    public class ProductStockEvent
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
