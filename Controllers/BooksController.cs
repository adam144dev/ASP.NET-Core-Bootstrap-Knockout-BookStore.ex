using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Controllers
{
    [ViewComponent(Name = "BooksFeatured")]
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: Books
        public IActionResult Index(int categoryId)
        {
            ViewData["SelectedCategoryId"] = categoryId;
            var books = _service.GetByCategoryId(categoryId);

            return View(AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books.ToList()));
        }

        public IActionResult Details(int id)
        {
            var book = _service.GetById(id);
            if (book == null)
                return NotFound();

            return View(AutoMapper.Mapper.Map<Book, BookViewModel>(book));
        }


        /// <summary>
        //  ViewController
        /// </summary>

        [ViewComponentContext]
        public ViewComponentContext ViewComponentContext { get; set; }

        public IViewComponentResult Invoke()
        {
            var books = _service.GetFeatured();

            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<List<BookViewModel>>(
                   ViewData,
                   AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books.ToList())
               )
            };
        }
    }
}
