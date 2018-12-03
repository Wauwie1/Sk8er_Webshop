using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_WebshopTest
{
    public class ProductMockContext : IProductContext<Product>
    {
        private List<Product> products;

        // Creates mock data
        public ProductMockContext()
        {
            products = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                Product product = new Product()
                {
                    Name = "Mock",
                    Collection = "MockCollection",
                    Description = "This is a moc product",
                    Id = i,
                    ImgURL = "MockURL",
                    Price = 100,
                    ProductType = "MockShirt",
                    Stock = new Stock()
                    {
                        Sizes = new List<Size>()
                    }
                };
                products.Add(product);
            }
        }

        public Product GetById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll(int page)
        {
            List<Product> returnList = new List<Product>();
            for (int i = page * 12; returnList.Count < 12; i++)
            {
                returnList.Add(products[i]);
            }

            return returnList;
        }

        public IEnumerable<Product> GetSearchedProducts(string search, int page)
        {
            List<Product> results = products.Where(p => p.Name == search).ToList();
            List<Product> returnList = new List<Product>();
            for (int i = page * 12; returnList.Count < 12; i++)
            {
                try
                {
                    returnList.Add(results[i]);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            return returnList;
        }

        public IEnumerable<Product> GetCategoryProducts(string category, int page)
        {
            List<Product> results = products.Where(p => p.ProductType == category).ToList();
            List<Product> returnList = new List<Product>();
            for (int i = page * 12; returnList.Count < 12; i++)
            {
                try
                {
                    returnList.Add(results[i]);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            return returnList;
        }

        public bool AddNewProduct(string name, string description, decimal price, string collection, string productType,
            string ImgUrl)
        {
            try
            {
                products.Add(new Product()
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Collection = collection,
                    ProductType = productType,
                    ImgURL = ImgUrl
                });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}