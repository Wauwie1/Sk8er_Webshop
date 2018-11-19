using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class ProductRepository
    {
        private IProductContext<Product> context;

        public ProductRepository(IProductContext<Product> context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll(int page)
        {
            return context.GetAll(page);
        }

        public Product GetById(int id)
        {
            return context.GetById(id);
        }

        public IEnumerable<Product> GetSearchedProducts(string search, int page)
        {
            return context.GetSearchedProducts(search, page);
        }

        public IEnumerable<Product> GetCategoryProducts(string category, int page)
        {
            return context.GetCategoryProducts(category, page);
        }

        public bool AddNewProduct(string name, string description, decimal price, string collection, string productType,
            string ImgUrl)
        {
            return context.AddNewProduct(name, description, price, collection, productType,
              ImgUrl);
        }
    }
}