using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface IStockContext<T> where T : IModel
    {
        T GetByProductId(int id);
        IEnumerable<T> GetAllStock();
    }
}