using System;
using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductLogic logic = new ProductLogic();
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public IActionResult All(int page = 0)
        {
            var viewModel = new AllProductViewModel
            {
                Page = page,
                Products = logic.GetAll(page)
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            try
            {
                var product = logic.GetById((id));
                return View(product);
            }
            catch (NullReferenceException ex)
            {
                return Content(string.Format("An error occured: {0} \n {1}", ex.Message, ex.GetBaseException()));
            }
        }

        public IActionResult Search(string search, int page)
        {
            var viewModel = new AllProductViewModel
            {
                Page = page,
                Search = search,
                Products = logic.GetSearchedProducts(search, page)
            };

            return View(viewModel);
        }

        public IActionResult Category(string category, int page)
        {
            var viewModel = new AllProductViewModel
            {
                Page = page,
                Category = category,
                Products = logic.GetCategoryProducts(category, page)
            };

            return View(viewModel);
        }
    }
}