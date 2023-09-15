using Dapr.Client;
using ShoppingCart.Domain;

namespace ShoppingCart.Services
{
    public class ShoppingCartServiceImp : IShoppingCartService
    {
        private readonly DaprClient _daprClient;
        public ShoppingCartServiceImp(DaprClient client)
        {
            _daprClient = client;
        }
        public async Task AddItemToCartAsync(string UserId, CartItem itemToAdd)
        {
            var shoppingCart = await GetShoppingCartAsync(UserId);

            var itemOnCart = shoppingCart.Items.Find(m => m.ProductID == itemToAdd.ProductID);

            if (itemOnCart != null)
                itemOnCart.Quantity += itemToAdd.Quantity;
            else
                shoppingCart.Items.Add(itemToAdd);

            await _daprClient.SaveStateAsync("statestore", UserId, shoppingCart);

        }
        public async Task<Domain.ShoppingCart> GetShoppingCartAsync(string UserId)
        {
            var shoppingCart = await _daprClient.GetStateAsync<Domain.ShoppingCart>("statestore", UserId);

            return shoppingCart == null ? new Domain.ShoppingCart() { UserId = UserId } : shoppingCart;
        }

        public async Task ProceedWithPayment(string userID)
        {
            Random random = new Random();

            var shoppingCart = GetShoppingCartAsync(userID).Result;

            double grossTotal = 0;

            foreach (var item in shoppingCart.Items)
            {
                grossTotal += item.Quantity * item.Price;
            }

            if (shoppingCart != null)
            {
                var integrationEvent = new PaymentRequestedIntegrationEvent()
                {
                    CartID = random.Next().ToString(),
                    Price = grossTotal.ToString("F2"),
                    UserID = userID
                };
                await _daprClient.PublishEventAsync("pubSub", "dapr.Payment", integrationEvent);
            }

        }
    }
}
