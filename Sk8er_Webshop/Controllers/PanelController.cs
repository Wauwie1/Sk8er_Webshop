using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Stock()
        {
            var viewModel = new StockViewModel
            {
                StockList = StockLogic.GetAllStock()
            };
            return View(viewModel);
        }
    }
}