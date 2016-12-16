using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public interface IAuthorRepository
    {
        IQueryable<Author> Authors { get; }

        void Insert(Author author);

        void Update(Author author);

        void Delete(Author author);
    }
}
