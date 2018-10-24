using System;
using System.Collections.Generic;
using System.Linq;
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
                //Removes sizes which are out of stock
                foreach (var size in product.Stock.Sizes.ToList())
                {
                    if (size.Amount == 0)
                    {
                        product.Stock.Sizes.Remove(size);
                    }
                }
                return product;
            }
        }

        private static List<Product> GetAllProducts(int page)
        {
            return ProductData.GetAllProducts(page);
        }
        private static List<Product> GetSearchedProducts(string search, int page)
        {
            return ProductData.GetSearchedProducts(search, page);
        }

        public static List<Product> GetProducts(string search, int page)
        {
            if (search != null)
            {
                return GetSearchedProducts(search, page);
            }
            else
            {
                return GetAllProducts(page); 
            }
        }

    }
}
