using System.Collections.Generic;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public interface IBookService
    {
        List<Book> Get();

        List<Book> GetByCategoryId(int categoryId);

        List<Book> GetFeatured();

        Book GetById(int id);
    }
}

