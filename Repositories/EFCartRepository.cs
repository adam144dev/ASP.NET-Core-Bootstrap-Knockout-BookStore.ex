using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public class EFCartRepository : EFBaseRepository<BookStoreDbContext, Cart>, ICartRepository
    {
        public EFCartRepository(BookStoreDbContext dbContext) 
            : base(dbContext)
        {
        }

        public IQueryable<Cart> Carts => Entities;

    }
}
