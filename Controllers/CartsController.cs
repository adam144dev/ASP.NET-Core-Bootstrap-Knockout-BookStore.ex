using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Controllers
{
    [ViewComponent(Name = "CartsSummary")]
    public class CartsController : Controller
    {
        private readonly ICartService _service;

        public CartsController(ICartService service)
        {
            _service = service;
        }

        // GET: Carts
        public ActionResult Index()
        {
            var cart = _service.GetBySessionId(HttpContext.Session.Id);

            return View(AutoMapper.Mapper.Map<Cart, CartViewModel>(cart));
        }


        /// <summary>
        // CartsSummary ViewController
        /// </summary>

        [ViewComponentContext]
        public ViewComponentContext ViewComponentContext { get; set; }
   
        public IViewComponentResult Invoke()
        {
            // (TBD?) A unique identifier for the current session. This is not the same as the session cookie 
            // since the cookie lifetime may not be the same as the session entry lifetime in the data store. 
            var cart = _service.GetBySessionId(ViewComponentContext.ViewContext.HttpContext.Session.Id);
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<CartViewModel>(
                    ViewData, 
                    AutoMapper.Mapper.Map<Cart, CartViewModel>(cart)
                )
            };
        }
    }
}
