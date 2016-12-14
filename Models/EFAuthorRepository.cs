using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models
{
    public class EFAuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _db;

        public EFAuthorRepository(BookStoreDbContext dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<Author> Authors => _db.Authors;
    }
}
