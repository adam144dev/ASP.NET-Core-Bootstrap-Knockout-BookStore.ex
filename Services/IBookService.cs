using System.Collections.Generic;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public interface IBookService
    {
        IEnumerable<Book> Get();

        IEnumerable<Book> GetByCategoryId(int categoryId);

        IEnumerable<Book> GetFeatured();

        Book GetById(int id);
    }
}

