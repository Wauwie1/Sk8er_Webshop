using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class StockRepository
    {
        private readonly IStockContext<Stock> _context;

        public StockRepository(IStockContext<Stock> context)
        {
            this._context = context;
        }

        public Stock GetByProductId(int id)
        {
            return _context.GetByProductId(id);
        }

        public IEnumerable<Stock> GetAllStock()
        {
            return _context.GetAllStock();
        }
    }
}