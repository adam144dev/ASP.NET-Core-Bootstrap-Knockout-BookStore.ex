using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        IQueryable<CartItem> CartItems { get; }
    }
}
