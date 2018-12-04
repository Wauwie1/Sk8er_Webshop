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
        private readonly BasketLogic logic = new BasketLogic(new ProductSQLContext());
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

        public IActionResult Pay(string firstName, string lastName, string userName, string email, string adress, string country, string zipcode)
        {
            List<string> customerInformation = new List<string>
            {
                firstName, lastName, userName, email, adress, country, zipcode
            };

            if (!logic.ContainsNull(customerInformation)  && Request.Cookies["BasketCookie"] != null)
            {
                //Return payment succesfull
                return RedirectToAction("PaymentSuccesful");
            }
            else
            {
                return RedirectToAction("PaymentFailed");
            }
        }

        public IActionResult PaymentFailed()
        {
            return View();
        }

        public IActionResult PaymentSuccesful()
        {
            return View();
        }
    }
}