using System.Collections.Generic;
using System.Linq;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class StockLogic
    {
        private StockRepository repository;

        public StockLogic(StockRepository repository)
        {
            this.repository = repository;
        }
        public List<Stock> GetAllStock()
        {
            return repository.GetAllStock().ToList();
        }
    }
}