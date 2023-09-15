using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("/shopping-basket")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;
        public ShoppingCartController(IShoppingCartService service)
        {
            _cartService = service;
        }

        [HttpGet("{userID}")]
        public async Task<ActionResult<Domain.ShoppingCart>> Get(string userId)
        {
            Domain.ShoppingCart shoppingCart = await _cartService.GetShoppingCartAsync(userId);

            return Ok(shoppingCart);
        }

        [HttpPost("{userId}/items")]
        public async Task<ActionResult<Domain.ShoppingCart>> Post(string userId, Domain.CartItem item)
        {
            try
            {
                await _cartService.AddItemToCartAsync(userId, item);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost("{check-out}")]
        public async Task<ActionResult> CheckOut(string UserId)
        {
            try
            {
                await _cartService.ProceedWithPayment(UserId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
