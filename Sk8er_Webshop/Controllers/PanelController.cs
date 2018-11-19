using System;
using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class PanelController : Controller
    {
        private readonly StockLogic stockLogic = new StockLogic();
        private readonly ProductLogic productLogic = new ProductLogic();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Stock()
        {
            var viewModel = new StockViewModel
            {
                StockList = stockLogic.GetAllStock()
            };
            return View(viewModel);
        }

        public IActionResult AddNewProduct()
        {
            return View();
        }

        public IActionResult AddNewProductToDB(string name, string description, decimal price, string collection, string productType,
            string ImgUrl)
        {
            if (productLogic.AddNewProduct(name, description, price, collection, productType,
                ImgUrl))
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