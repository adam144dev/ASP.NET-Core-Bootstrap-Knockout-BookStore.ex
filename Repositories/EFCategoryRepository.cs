using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public class EFCategoryRepository : EFBaseRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(BookStoreDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Category> Categories => Entities;

    }
}
