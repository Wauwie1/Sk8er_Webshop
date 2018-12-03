using System;
using System.Collections.Generic;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_WebshopTest
{
    public class StockMockContext : IStockContext<Stock>
    {
        private List<Stock> stocks { get; }
        public StockMockContext()
        {
            stocks = new List<Stock>();
            for (int i = 0; i < 100; i++)
            {
                var stock = new Stock()
                {
                    Id = i,
                    ProductKey = i,
                    ProductName = "MockStockProduct",
                    Sizes = new List<Size>()
                };
                Random random = new Random();
                stock.Sizes.Add(new Size(EnumSizes.M, random.Next(0, 51)));
                stocks.Add(stock);
            }
            
        }
        public Stock GetByProductId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Stock> GetAllStock()
        {
            return stocks;
        }
    }
}