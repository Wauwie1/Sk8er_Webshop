using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductLogic _logic;

        public ProductController(IConfiguration configuration)
        {
            _logic = new ProductLogic(new ProductSqlContext(configuration));
        }
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public IActionResult All(int page = 0)
        {
            var viewModel = new AllProductViewModel
            {
                Page = page,
                Products = _logic.GetAll(page)
            };

            return View(viewModel);
        }
        // todo: vervang catch
        public IActionResult Details(int id)
        {
            try
            {
                var product = _logic.GetById(id);
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
                Products = _logic.GetSearchedProducts(search, page)
            };

            return View(viewModel);
        }

        public IActionResult Category(string category, int page)
        {
            var viewModel = new AllProductViewModel
            {
                Page = page,
                Category = category,
                Products = _logic.GetCategoryProducts(category, page)
            };

            return View(viewModel);
        }
    }
}