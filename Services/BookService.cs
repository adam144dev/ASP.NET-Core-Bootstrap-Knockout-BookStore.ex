using System.Collections.Generic;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;
using System.Linq;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> Get()
        {
            return _repository.Books.ToList();
        }

        public List<Book> GetByCategoryId(int categoryId)
        {
            return _repository
                .EntitiesInclude("Author")
                .Where(b => b.CategoryId == categoryId).
                OrderByDescending(b => b.Featured).
                ToList();
        }
    }
}

