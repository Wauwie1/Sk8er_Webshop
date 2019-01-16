using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;

namespace Sk8er_WebshopTest
{
    [TestClass]
    public class StockLogicTest
    {
        private readonly StockLogic _logic = new StockLogic(new StockMockContext());
        [TestMethod]
        public void GetAllStock1()
        {
            List<Stock> stocks = _logic.GetAllStock();
            Assert.IsTrue(stocks.Count > 0);
        }
    }
}