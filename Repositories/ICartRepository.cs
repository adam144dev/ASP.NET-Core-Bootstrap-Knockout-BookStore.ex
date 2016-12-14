using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public interface ICartRepository
    {
        //IEnumerable<Cart> Carts { get; }
        IQueryable<Cart> Carts { get; }

        void Insert(Cart cart);

        void Update(Cart cart);

        void Delete(Cart cart);
    }
}
