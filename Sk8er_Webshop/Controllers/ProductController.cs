using System;
using Microsoft.AspNetCore.Mvc;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.ViewModels;

namespace Sk8er_Webshop.Controllers
{
    public class ProductController : Controller
    {
        private ProductLogic logic = new ProductLogic(new ProductRepository(new ProductSQLContext()));
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }

        public IActionResult All(string search, string category, int page = 0)
        {
            var viewModel = new AllProductViewModel
            {
                Page = page,
                Category = category,
                Search = search,
                Products = ProductLogic.GetProducts(search, category, page)
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
    }
}