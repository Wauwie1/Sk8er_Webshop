using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Logic;

namespace Sk8er_WebshopTest
{
    [TestClass]
    public class ProductLogicTest
    {
        ProductLogic logic = new ProductLogic();
        
        [TestMethod]
        public void AddNewItemTest()
        {
           Assert.IsTrue(logic.AddNewProduct("TestProduct", "TestDesc", 12.8m, "Summer", "Shirt", "test")); 
        }
    }
}