using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public class EFCartItemRepository : EFBaseRepository<CartItem>, ICartItemRepository
    {
        public EFCartItemRepository(BookStoreDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<CartItem> CartItems => Entities;

    }
}
