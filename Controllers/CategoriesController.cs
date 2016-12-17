using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Controllers
{
    [ViewComponent(Name = "CategoriesMenu")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}


        /// <summary>
        //  ViewController
        /// </summary>

        [ViewComponentContext]
        public ViewComponentContext ViewComponentContext { get; set; }

        public IViewComponentResult Invoke(int? selectedCategoryId)
        {
            ViewData["SelectedCategoryId"] = selectedCategoryId;
            var categories = _service.Get();

            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<List<CategoryViewModel>>(
                   ViewData,
                   AutoMapper.Mapper.Map<List<Category>, List<CategoryViewModel>>(categories.ToList())
               )
            };
        }

    }
}
