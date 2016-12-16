using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<Category> Get()
        {
            return _repository.Categories.ToList();
        }
    }
}
