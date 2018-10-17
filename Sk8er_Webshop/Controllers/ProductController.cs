using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var Products = new List<Product>
            {
                new Product {Name = "Kanariegele trui"},
                new Product {Name = "Lelijke broek"},
                new Product {Name = "Vans 200x"}
            };

            var viewModel = new AllProductViewModel
            {
                products = Products
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            return View(ProductLogic.GetProductById(id));
        }
    }
}