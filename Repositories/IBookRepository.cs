using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        void Insert(Book entity);

        void Update(Book entity);

        void Delete(Book entity);
    }
}
