using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class PanelController : Controller
    {
        private readonly StockLogic _stockLogic;
        private readonly ProductLogic _productLogic;
        private readonly PanelLogic _logic;
        private User _user;

        public PanelController(IConfiguration configuration)
        {
            _stockLogic = new StockLogic(new StockSqlContext(configuration));
            _productLogic = new ProductLogic(new ProductSqlContext(configuration));
            _logic = new PanelLogic(new PanelSqlContext(configuration));
        }
        public IActionResult Index()
        {

            if (ValidUser())
            {
                return View();
            }
            else
            {
                return Content("No permission");
            }
            
            
        }

        private bool ValidUser()
        {
            SetUser();
            if (_user != null && _user.AuthLevel == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SetUser()
        {
            string userJson = HttpContext.Session.GetString("User");
            try
            {
                _user = JsonConvert.DeserializeObject<User>(userJson);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                _user = null;
            }
            
        }

        public IActionResult Stock()
        {
            var viewModel = new StockViewModel
            {
                StockList = _stockLogic.GetAllStock()
            };

            if (ValidUser())
            {
                return View(viewModel);
            }
            else
            {
                return Content("No permission");
            }
        }

        public IActionResult AddNewProduct()
        {
            if (ValidUser())
            {
                return View();
            }
            else
            {
                return Content("No permission");
            }
        }

        public IActionResult AddNewProductToDb(string name, string description, decimal price, string collection, string productType,
            string imgUrl)
        {
            if (_productLogic.AddNewProduct(name, description, price, collection, productType,
                imgUrl) && ValidUser())
            {
                return RedirectToAction("NewProductSuccesfull");
            }
            else
            {
                return RedirectToAction("NewProductFailed");
            }

        }

        public IActionResult NewProductSuccesfull()
        {
            return View();
        }
        public IActionResult NewProductFailed()
        {
            return View();
        }

        public IActionResult AllOrders()
        {
            AllOrdersViewModel viewModel = new AllOrdersViewModel()
            {
                Orders = _logic.GetAllOrders()
            };
            return View(viewModel);
        }

        public IActionResult OrdersAmount()
        {
            var viewModel = new OrdersAmountViewModel()
            {
                UserOrdersAmount = _logic.GetUserOrdersAmount(),
                TotalOrders = _logic.GetTotalOrders()
            };
            return View(viewModel);
        }
    }
}