using Microsoft.AspNetCore.Mvc;

namespace MultiShop.RapidApi.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
