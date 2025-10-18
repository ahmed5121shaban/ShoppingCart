using Contracts;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
namespace Controllers
{
    [Route("/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartStore _shoppingCartStore;
        public ShoppingCartController(IShoppingCartStore shoppingCartStore) 
        {
            _shoppingCartStore = shoppingCartStore;
        }
        
        [HttpGet("{userId:int}")]
        public ShoppingCart GetShoppingCart(int userId)
        => _shoppingCartStore.Get(userId);

        [HttpPost("{userId:int}/items")]
        public async Task<ShoppingCart> Post(int userId, [FromBody] int[] productIds)
        {
            var shoppingCart = _shoppingCartStore.Get(userId);
            var shoppingCartItems = await this.productcatalogClient.GetShoppingCartItems(productIds);
            shoppingCart.AddItems(shoppingCartItems, eventStore);
            return shoppingCart;
        }
    }
}
