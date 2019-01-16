using System.Collections.Generic;
using System.Linq;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class StockLogic
    {
        private readonly StockRepository _repository;

        public StockLogic(IStockContext<Stock> context)
        {
            _repository = new StockRepository(context);
        }
        public List<Stock> GetAllStock()
        {
            return _repository.GetAllStock().ToList();
        }
    }
}