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

        // POST api/values
        // PUT api/values
        [HttpPost]
        [HttpPut]
        public CartItemViewModel Post([FromBody]CartItemViewModel cartItem)
        {
            var newCartItem = _service.AddToCart(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItem));
            return AutoMapper.Mapper.Map<CartItem, CartItemViewModel>(newCartItem);
        }
    }
}
