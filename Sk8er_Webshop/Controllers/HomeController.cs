using Microsoft.AspNetCore.Mvc;

namespace Sk8er_Webshop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}