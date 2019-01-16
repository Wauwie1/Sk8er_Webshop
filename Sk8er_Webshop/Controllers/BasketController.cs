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
                if (!String.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return Content("Order could not be processed");
            }
        }

        public IActionResult Pay(string firstName, string lastName, string email, string adress, int number, string city, string country, string zipcode)
        {
            _cookie = Request.Cookies["BasketCookie"];

            if (_cookie != null)
            {
                // Get User
                string userString = HttpContext.Session.GetString("User");
                User user = _loginLogic.GetUser(userString);

                // Update user

                Order order = new Order()
                {
                    
                    ProductsJson = _cookie,
                    UserKey = user.Id,
                    AdressKey = _loginLogic.SetAdress(adress, number, city, country, zipcode),
                    Status = 0,
                    FirstName = firstName,
                    LastName = lastName

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