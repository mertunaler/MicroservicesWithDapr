using Microsoft.AspNetCore.Http.Features;

namespace ShoppingCart.Domain
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
