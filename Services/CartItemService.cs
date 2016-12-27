using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;
using System.Linq;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repository;

        public CartItemService(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public CartItem AddToCart(CartItem cartItem)
        {
            var entityCartItem = _repository.CartItems.SingleOrDefault(ci => ci.CartId == cartItem.CartId && ci.BookId == cartItem.BookId);

            if (entityCartItem != null)
            {
                entityCartItem.Quantity += cartItem.Quantity;
                _repository.Update(entityCartItem);
            }
            else
            {
                entityCartItem = cartItem;
                _repository.Add(entityCartItem);
            }

            return entityCartItem;
        }

        public void DeleteCartItem(CartItem cartItem) => _repository.Delete(cartItem);
    }
}