using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }


        public Cart GetBySessionId(string sessionId)
        {
            return _repository
                    .EntitiesInclude("CartItems")
                    .SingleOrDefault(c => c.SessionId == sessionId) 
                ?? CreateCart(sessionId);
        }

        private Cart CreateCart(string sessionId)
        {
            var cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };

            _repository.Add(cart);

            return cart;
        }
    }
}
