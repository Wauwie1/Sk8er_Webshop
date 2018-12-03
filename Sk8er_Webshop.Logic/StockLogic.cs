using System.Collections.Generic;
using System.Linq;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class StockLogic
    {
        private StockRepository repository;

        public StockLogic(IStockContext<Stock> context)
        {
            repository = new StockRepository(context);
        }
        public List<Stock> GetAllStock()
        {
            return repository.GetAllStock().ToList();
        }
    }
}