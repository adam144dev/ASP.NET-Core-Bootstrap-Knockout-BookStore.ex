using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public class EFBookRepository : EFBaseRepository<BookStoreDbContext, Book>, IBookRepository
    {
        public EFBookRepository(BookStoreDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Book> Books => Entities;

    }
}
