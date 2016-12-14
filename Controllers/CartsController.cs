using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService _service;

        public CartsController(ICartService service)
        {
            _service = service;
        }

        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}


        // TBD: [ChildActionOnly]
        public PartialViewResult Summary()
        {
            // (TBD?) A unique identifier for the current session. This is not the same as the session cookie 
            // since the cookie lifetime may not be the same as the session entry lifetime in the data store. 
            var cart = _service.GetBySessionId(HttpContext.Session.Id);
            return PartialView(AutoMapper.Mapper.Map<CartViewModel>(cart));
        }


    }
}
