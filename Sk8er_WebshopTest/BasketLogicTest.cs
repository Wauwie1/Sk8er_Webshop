using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;

namespace Sk8er_WebshopTest
{
    [TestClass]
    public class BasketLogicTest
    {
        BasketLogic logic = new BasketLogic(new ProductMockContext());

        [TestMethod]
        public void JSONToBasketItems1()
        {
            List<BasketItem> items = logic.JSONToBasketItems(null);
            Assert.IsTrue(items.Count == 0);
        }
        [TestMethod]
        public void JSONToBasketItems2()
        {
            List<BasketItem> items = logic.JSONToBasketItems("InvalidString");
            Assert.IsNull(items);
        }
        [TestMethod]
        public void JSONToBasketItems3()
        {
            //Correct string
            string JSON = "[{\"Id\":3,\"Amount\":1,\"Size\":\"S\"}]";
            List<BasketItem> items = logic.JSONToBasketItems(JSON);
            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void ContainsNull1()
        {
            List<string> strings = new List<string>();
            
            strings.Add("string");
            strings.Add("string");
            strings.Add("");
            strings.Add("string");
            strings.Add("string");
            strings.Add("string");

            bool containsNull = logic.ContainsNull(strings);
            Assert.IsTrue(containsNull);
        }
        [TestMethod]
        public void ContainsNull2()
        {
            List<string> strings = new List<string>();

            strings.Add("string");
            strings.Add("string");
            strings.Add("string");
            strings.Add("string");
            strings.Add("string");
            strings.Add("string");

            bool containsNull = logic.ContainsNull(strings);
            Assert.IsFalse(containsNull);
        }

        [TestMethod]
        public void ContainsNull3()
        {
            List<string> strings = new List<string>();


            bool containsNull = logic.ContainsNull(strings);
            Assert.IsTrue(containsNull);
        }
    }
}