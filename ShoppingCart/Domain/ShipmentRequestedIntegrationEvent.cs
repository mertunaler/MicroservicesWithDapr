namespace ShoppingCart.Domain
{
    public class ShipmentRequestedIntegrationEvent
    {
        public string Address { get; set; }
        public string UserID { get; set; }
    }
}
