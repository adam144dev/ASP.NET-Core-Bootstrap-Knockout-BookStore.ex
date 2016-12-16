using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public class EFAuthorRepository : EFBaseRepository<Author>, IAuthorRepository
    {
        public EFAuthorRepository(BookStoreDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Author> Authors => Entities;

    }
}
