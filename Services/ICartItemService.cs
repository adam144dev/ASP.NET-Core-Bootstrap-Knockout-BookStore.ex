using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public interface ICartItemService
    {
        CartItem AddToCart(CartItem cartItem);
    }
}

