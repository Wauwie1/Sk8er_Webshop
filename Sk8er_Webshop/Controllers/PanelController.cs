using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class PanelController : Controller
    {
        private readonly StockLogic logic = new StockLogic();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Stock()
        {
            var viewModel = new StockViewModel
            {
                StockList = logic.GetAllStock()
            };
            return View(viewModel);
        }
    }
}