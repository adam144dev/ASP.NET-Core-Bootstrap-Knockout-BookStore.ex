using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Controllers
{
    //[ViewComponent(Name = "CategoriesMenu")]
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: Books
        public ActionResult Index(int categoryId)
        {
            var books = _service.GetByCategoryId(categoryId);

            ViewBag.SelectedCategoryId = categoryId;

            return View(AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books));
        }


        ///// <summary>
        //// CartsSummary ViewController
        ///// </summary>

        //[ViewComponentContext]
        //public ViewComponentContext ViewComponentContext { get; set; }

        //public IViewComponentResult Invoke(int? selectedCategoryId)
        //{
        //    var categories = _service.Get();
        //    ViewBag.SelectedCategoryId = selectedCategoryId;

        //    return new ViewViewComponentResult()
        //    {
        //        ViewData = new ViewDataDictionary<List<CategoryViewModel>>(
        //           ViewData,
        //           AutoMapper.Mapper.Map<List<Category>, List<CategoryViewModel>>(categories)
        //       )
        //    };
        //}

    }
}
