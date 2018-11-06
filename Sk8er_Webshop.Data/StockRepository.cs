using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class StockRepository
    {
        private readonly IStockContext<Stock> context;

        public StockRepository(IStockContext<Stock> context)
        {
            this.context = context;
        }

        public Stock GetByProductId(int id)
        {
            return context.GetByProductId(id);
        }

        public IEnumerable<Stock> GetAllStock()
        {
            return context.GetAllStock();
        }
    }
}