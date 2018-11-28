using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Data;

namespace Sk8er_WebshopTest
{
    [TestClass]
    public class ProductDataTest
    {
        [TestMethod]
        public void AddNewProductTest()
        {
            ProductSQLContext context = new ProductSQLContext();
            bool succesful = context.AddNewProduct("Hoi", "Hoi", 2, "Hoi", "Hoi", "Hoi");
            Assert.IsTrue(succesful);
        }
    }
}
