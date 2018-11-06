using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class BasketController : Controller
    {
        BasketLogic logic = new BasketLogic(new ProductRepository(new ProductSQLContext()));
        public IActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public IActionResult Overview()
        {
            string cookie = Request.Cookies["BasketCookie"];

            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = logic.JSONToBasketItems(cookie),
            };
            return View(viewModel);
        }
    }
}