using System;
using System.Collections.Generic;
using System.Linq;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public static class ProductLogic
    {
        public static Product GetProductById(int id)
        {
            var product = ProductData.GetProductById(id);


            //If no product found
            if (product == null) throw new NullReferenceException("No product with this ID has been found.");

            //Removes sizes which are out of stock
            foreach (var size in product.Stock.Sizes.ToList())
                if (size.Amount == 0)
                    product.Stock.Sizes.Remove(size);
            return product;
        }

        public static List<Product> GetProducts(string search, string category, int page)
        {
            if (search != null)
                return GetSearchedProducts(search, page);
            if (category != null)
                return GetProductsCategory(category, page);
            return GetAllProducts(page);
        }

        private static List<Product> GetProductsCategory(string category, int page)
        {
            return ProductData.GetProductsCategory(category, page);
        }

        private static List<Product> GetAllProducts(int page)
        {
            return ProductData.GetAllProducts(page);
        }

        private static List<Product> GetSearchedProducts(string search, int page)
        {
            return ProductData.GetSearchedProducts(search, page);
        }
    }
}