using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class ProductRepository
    {
        private IProductContext<Product> _context;

        public ProductRepository(IProductContext<Product> context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetAll(int page)
        {
            return _context.GetAll(page);
        }

        public Product GetById(int id)
        {
            return _context.GetById(id);
        }

        public IEnumerable<Product> GetSearchedProducts(string search, int page)
        {
            return _context.GetSearchedProducts(search, page);
        }

        public IEnumerable<Product> GetCategoryProducts(string category, int page)
        {
            return _context.GetCategoryProducts(category, page);
        }

        public bool AddNewProduct(string name, string description, decimal price, string collection, string productType,
            string imgUrl)
        {
            return _context.AddNewProduct(name, description, price, collection, productType,
              imgUrl);
        }

        public void PlaceOrder(Order order)
        {
            _context.PlaceOrder(order);
        }
    }
}