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
        private readonly BasketLogic logic;
        private readonly LoginLogic loginLogic;
        private string cookie;

        public BasketController(IConfiguration configuration)
        {
            logic = new BasketLogic(new ProductSQLContext(configuration));
            loginLogic = new LoginLogic(new LoginSQLContext(configuration));
        }
        public IActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public IActionResult Overview()
        {
             cookie = Request.Cookies["BasketCookie"];

            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = logic.JSONTOBasketItems(cookie),
            };
            return View(viewModel);
        }

        public IActionResult Checkout()
        {
            cookie = Request.Cookies["BasketCookie"];
            BasketViewModel viewModel = new BasketViewModel()
            {
                BasketItems = logic.JSONTOBasketItems(cookie),
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
                User user = loginLogic.GetUser(userString);

                Order order = new Order()
                {
                    
                    ProductsJSON = Request.Cookies["BasketCookie"],
                    UserKey = user.Id,
                    Status = 0

                };
                logic.PlaceOrder(order);

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