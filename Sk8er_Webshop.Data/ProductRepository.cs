using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class ProductRepository
    {
        private IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.GetAll();
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
    }
}