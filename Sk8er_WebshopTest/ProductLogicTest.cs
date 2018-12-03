using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;

namespace Sk8er_WebshopTest
{
    [TestClass]
    public class ProductLogicTest
    {
        ProductLogic logic = new ProductLogic(new ProductMockContext());
        
        [TestMethod]
        public void GetById1()
        {
           Product product = new Product();
            product = logic.GetById(1);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
            "No product with this ID has been found.")]
        public void GetById2()
        {
            Product product = new Product();
            product = logic.GetById(999);
        }

        [TestMethod]
        public void GetAll1()
        {
            List<Product> products = logic.GetAll(0);
            Assert.IsTrue(products.Count == 12);
        }
        [TestMethod]
        public void GetAll2()
        {
            List<Product> products = logic.GetAll(0);
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void GetSearchedProducts1()
        {
            List<Product> products = logic.GetSearchedProducts("Mock", 2);
            Assert.IsTrue(products.Count > 1);
        }

        [TestMethod]
        public void GetSearchedProducts2()
        {
            List<Product> products = logic.GetSearchedProducts("NoResults", 0);
            Assert.IsTrue(products.Count == 0);
        }

        [TestMethod]
        public void GetSearchedProducts3()
        {
            List<Product> products = logic.GetSearchedProducts(null, 0);
            Assert.IsTrue(products.Count == 0);
        }

        [TestMethod]
        public void GetCategoryProducts1()
        {
            List<Product> products = logic.GetCategoryProducts("MockShirt", 0);
            Assert.IsTrue(products.Count > 1);
        }

        [TestMethod]
        public void GetCategoryProducts2()
        {
            List<Product> products = logic.GetCategoryProducts("NoResults", 0);
            Assert.IsTrue(products.Count == 0);
        }

        [TestMethod]
        public void GetCategoryProducts3()
        {
            List<Product> products = logic.GetCategoryProducts(null, 0);
            Assert.IsTrue(products.Count == 0);
        }

        [TestMethod]
        public void AddNewProduct1()
        {
            bool succesful = logic.AddNewProduct("MockData", "MockData", 5, "MockData", "MockData", "MockData");

            Assert.IsTrue(succesful);
        }
    }
}