using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketLogic _logic;
        private readonly LoginLogic _loginLogic;
        private string _cookie;

        public BasketController(IConfiguration configuration)
        {
            _logic = new BasketLogic(new ProductSqlContext(configuration));
            _loginLogic = new LoginLogic(new LoginSqlContext(configuration));
        }
        public IActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public IActionResult Overview()
        {
             _cookie = Request.Cookies["BasketCookie"];

            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = _logic.JsontoBasketItems(_cookie),
            };
            return View(viewModel);
        }

        public IActionResult Checkout()
        {
            _cookie = Request.Cookies["BasketCookie"];
            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = _logic.JsontoBasketItems(_cookie),
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
            if (Request.Cookies["BasketCookie"] != null)
            {
                string userString = HttpContext.Session.GetString("User");
                User user = _loginLogic.GetUser(userString);

                Order order = new Order()
                {
                    
                    ProductsJson = Request.Cookies["BasketCookie"],
                    UserKey = user.Id,
                    Status = 0

                };
                _logic.PlaceOrder(order);

                // Empties basket
                HttpContext.Response.Cookies.Delete("BasketCookie");

                // Return payment succesfull
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