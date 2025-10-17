using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers.ShoppingCart
{
    [Route("/")] // instead of ( api/[controller] )
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("Hello World!");
        }
    }
}
