using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;
using Microsoft.EntityFrameworkCore;

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
            return _repository.Books.
                Include("Author").
                Where(b => b.CategoryId == categoryId).
                OrderByDescending(b => b.Featured).
                ToList();
        }
    }
}

