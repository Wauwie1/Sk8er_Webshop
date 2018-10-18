using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public static class ProductLogic
    {
        public static Product GetProductById(int id)
        {
           
            Product product = ProductData.GetProductById(id);

            if (product == null)
            {
                throw new NullReferenceException("No product with this ID has been found.");
            }
            else
            {
                return product;
            }
        }

        public static List<Product> GetAllProducts()
        {
            return ProductData.GetAllProducts();
        }
        public static List<Product> GetSearchedProducts(string search)
        {
            return ProductData.GetSearchedProducts(search);
        }
    }
}
