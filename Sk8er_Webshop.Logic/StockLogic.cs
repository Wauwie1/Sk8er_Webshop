using System.Collections.Generic;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class StockLogic
    {
        public static List<Stock> GetAllStock()
        {
            return StockData.GetAllStock();
        }
    }
}