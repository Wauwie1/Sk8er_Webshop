using System;
using System.Collections.Generic;
using System.Linq;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class ProductLogic
    {
        private readonly ProductRepository _repository;
        public ProductLogic(IProductContext<Product> context)
        {
            _repository = new ProductRepository(context);
            
        }

        public List<Product> GetAll(int page)
        {
            return _repository.GetAll(page).ToList();
        }
        public Product GetById(int id)
        {
            Product product = _repository.GetById(id);

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
                products = _repository.GetSearchedProducts(search, page).ToList();
            }

            return products;
        }

        public List<Product> GetCategoryProducts(string category, int page)
        {
            return _repository.GetCategoryProducts(category, page).ToList();
        }

        public bool AddNewProduct(string name, string description, decimal price, string collection, string productType, string imgUrl)
        {
            return _repository.AddNewProduct(name, description, price, collection, productType,
                imgUrl);
        }
    }
}