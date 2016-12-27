using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Controllers.Api
{
    [Route("api/[controller]")]
    public class CartItemsController : Controller
    {
        private readonly ICartItemService _service;

        public CartItemsController(ICartItemService service)
        {
            _service = service;
        }

        //[Produces("application/json")]
        [HttpPost]
        public IActionResult Post([FromBody]CartItemViewModel cartItem)
        {
            if (cartItem == null)
                return BadRequest();

            var newCartItem = _service.AddToCart(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));
            return Ok(newCartItem);
        }

        //[Produces("application/json")]
        [HttpPut]
        public IActionResult Put([FromBody]CartItemViewModel cartItem)
        {
            if (cartItem == null)
                return BadRequest();

            var updatedCartItem = _service.AddToCart(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));
            
            return Ok(updatedCartItem);
        }

        // DELETE api/values
        [HttpDelete]
        public IActionResult Delete([FromBody]CartItemViewModel cartItem)
        {
            if (cartItem == null)
                return BadRequest();

            _service.DeleteCartItem(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return new OkResult();
        }
    }
}
