using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Logic;

namespace Sk8er_WebshopTest
{
    [TestClass]
    public class BasketLogicTest
    {
        private BasketLogic logic = new BasketLogic();
        [TestMethod]
        public void ContainsNullTest()
        {
            List<string> stringList = new List<string>
            {
                null, "Test", "Test2", "Test", "Test2", "Test", "Test2"
            };

            bool test = logic.ContainsNull(stringList);
            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void ContainsNullTest2()
        {
            List<string> stringList = new List<string>
            {
                "Test", "Test", "Test2", "Test", "Test2", "Test", "Test2"
            };

            bool test = logic.ContainsNull(stringList);
            Assert.AreEqual(false, test);
        }
    }
}