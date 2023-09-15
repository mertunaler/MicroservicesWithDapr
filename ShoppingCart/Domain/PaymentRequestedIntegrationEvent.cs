namespace ShoppingCart.Domain
{
    public class PaymentRequestedIntegrationEvent
    {
        public string CartID { get; set; }
        public string UserID { get; set; }
        public string Price { get; set; }  

    }
}
