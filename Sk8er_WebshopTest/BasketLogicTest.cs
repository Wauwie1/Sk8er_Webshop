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
        BasketLogic _logic = new BasketLogic(new ProductMockContext());

        [TestMethod]
        public void JsonToBasketItems1()
        {
            List<BasketItem> items = _logic.JsontoBasketItems(null);
            Assert.IsTrue(items.Count == 0);
        }
        [TestMethod]
        public void JsonToBasketItems2()
        {
            List<BasketItem> items = _logic.JsontoBasketItems("InvalidString");
            Assert.IsNull(items);
        }
        [TestMethod]
        public void JsonToBasketItems3()
        {
            //Correct string
            string json = "[{\"Id\":3,\"Amount\":1,\"Size\":\"S\"}]";
            List<BasketItem> items = _logic.JsontoBasketItems(json);
            Assert.IsTrue(items.Count > 0);
        }

       
    }
}