using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketLogic logic = new BasketLogic();
        private string cookie;
        public IActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public IActionResult Overview()
        {
             cookie = Request.Cookies["BasketCookie"];

            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = logic.JSONToBasketItems(cookie),
            };
            return View(viewModel);
        }

        public IActionResult Checkout()
        {
            cookie = Request.Cookies["BasketCookie"];
            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = logic.JSONToBasketItems(cookie),
            };

            if (viewModel.BasketItems.Count > 0)
            {
                return View();
            }
            else
            {
                return Content("Order could not be processed");
            }
        }
    }
}