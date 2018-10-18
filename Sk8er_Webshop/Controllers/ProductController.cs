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

        public IActionResult All(string search, int page = 0)
        {
            var viewModel = new AllProductViewModel();
            viewModel.Page = page;
            viewModel.Search = search;
            if (search != null)
            {
                
                viewModel.Products = ProductLogic.GetSearchedProducts(search,  page);

                return View(viewModel);
            }
            else
            {
                viewModel.Products = ProductLogic.GetAllProducts(page);
                return View(viewModel);
            }
        }

        

        public IActionResult Details(int id)
        {
            try
            {
                Product product = ProductLogic.GetProductById(id);
                return View(product);
            }
            catch (NullReferenceException e)
            {
                return Content(string.Format("An error occured: {0} \n {1}", e.Message, e.GetBaseException()));
            }
            
        }
    }
}