using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class PanelController : Controller
    {
        private readonly StockLogic stockLogic = new StockLogic(new StockSQLContext());
        private readonly ProductLogic productLogic = new ProductLogic(new ProductSQLContext());
        private User user;
        public IActionResult Index()
        {

            if (validUser())
            {
                return View();
            }
            else
            {
                return Content("No permission");
            }
            
            
        }

        private bool validUser()
        {
            setUser();
            if (user != null && user.AuthLevel == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void setUser()
        {
            string userJSON = HttpContext.Session.GetString("User");
            try
            {
                user = JsonConvert.DeserializeObject<User>(userJSON);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                user = null;
            }
            
        }

        public IActionResult Stock()
        {
            var viewModel = new StockViewModel
            {
                StockList = stockLogic.GetAllStock()
            };

            if (validUser())
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
            if (validUser())
            {
                return View();
            }
            else
            {
                return Content("No permission");
            }
        }

        public IActionResult AddNewProductToDB(string name, string description, decimal price, string collection, string productType,
            string ImgUrl)
        {
            if (productLogic.AddNewProduct(name, description, price, collection, productType,
                ImgUrl) && validUser())
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
    }
}