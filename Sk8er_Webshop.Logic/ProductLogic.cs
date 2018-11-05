using System;
using System.Collections.Generic;
using System.Linq;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public  class ProductLogic
    {
        private ProductRepository repository;
        public ProductLogic(ProductRepository repository)
        {
            this.repository = repository;
        }

        public List<Product> GetAll(int page)
        {
            return repository.GetAll(page).ToList();
        }
        public Product GetById(int id)
        {
            Product product = repository.GetById(id);

            //If no product found
            if (product == null)
            {
                throw new NullReferenceException("No product with this ID has been found.");
            }

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

        public List<Product> GetSearchedProducts(string search, int page)
        {
            List<Product> products;

            if (search == null)
            {
                products = new List<Product>();
            }
            else
            {
                products = repository.GetSearchedProducts(search, page).ToList();
            }

            return products;
        }


        //public static List<Product> GetProducts(string search, string category, int page)
        //{
        //    if (category != null)
        //        return GetProductsCategory(category, page);
        //    return GetAllProducts(page);
        //}

        //    private static List<Product> GetProductsCategory(string category, int page)
        //    {
        //        return ProductData.GetProductsCategory(category, page);
        //    }

        //    private static List<Product> GetAllProducts(int page)
        //    {
        //        return ProductData.GetAllProducts(page);
        //    }

        //    private static List<Product> GetSearchedProducts(string search, int page)
        //    {
        //        return ProductData.GetSearchedProducts(search, page);
        //    }
        public List<Product> GetCategoryProducts(string category, int page)
        {
            return repository.GetCategoryProducts(category, page).ToList();
        }
    }
}