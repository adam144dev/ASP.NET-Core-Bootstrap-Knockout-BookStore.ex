using System.Collections.Generic;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public IList<Book> Get()
        {
            return _repository.Books.ToList();
        }

        public IList<Book> GetByCategoryId(int categoryId)
        {
            return _repository
                .Include("Author")
                .Where(b => b.CategoryId == categoryId).
                OrderByDescending(b => b.Featured)
                .ToList();
        }

        public IList<Book> GetFeatured()
        {
            return _repository
                .Include("Author")
                .Where(b => b.Featured)
                .ToList();
        }

        public Book GetById(int id)
        {
            var book = _repository
                .Include("Author")
                .SingleOrDefault(b => b.Id == id);

            return book;
        }
    }
}

