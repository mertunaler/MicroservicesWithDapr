using Microsoft.Extensions.Configuration.UserSecrets;
using ShoppingCart.Domain;

namespace ShoppingCart.Services
{
    public interface IShoppingCartService
    {
        Task AddItemToCartAsync(string UserId, CartItem itemToAdd);
        Task<Domain.ShoppingCart> GetShoppingCartAsync(string UserId);

        Task ProceedWithPayment(string userID);
    }
}
