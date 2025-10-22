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
        private readonly IProductCatalogClient _productcatalogClient;
        public ShoppingCartController(IShoppingCartStore shoppingCartStore, IProductCatalogClient productcatalogClient)
        {
            _shoppingCartStore = shoppingCartStore;
            _productcatalogClient = productcatalogClient;
        }

        [HttpGet("{userId:int}")]
        public ShoppingCart GetShoppingCart(int userId)
        => _shoppingCartStore.Get(userId);

        [HttpPost("{userId:int}/items")]
        public async Task<ShoppingCart> Post(int userId, [FromBody] int[] productIds)
        {
            var shoppingCart = _shoppingCartStore.Get(userId);
            var shoppingCartItems = await _productcatalogClient.GetShoppingCrtItems(productIds);
            shoppingCart.AddItems(shoppingCartItems, eventStore);
            return shoppingCart;
        }

        [HttpDelete("{userid:int}/items")]
        public ShoppingCart Delete( int userId,[FromBody] int[] productIds)
        {
            var shoppingCart = _shoppingCartStore.Get(userId);
            shoppingCart.RemoveItems( productIds,this.eventStore);
            _shoppingCartStore.Save(shoppingCart);
            return shoppingCart;
        }
    }
}
