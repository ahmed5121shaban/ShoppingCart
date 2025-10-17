using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Domains;
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
            
    }
}
