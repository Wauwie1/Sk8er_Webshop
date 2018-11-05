using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface IProductContext : IContext<Product>
    {
        IEnumerable<Product> GetAll(int page);
        IEnumerable<Product> GetSearchedProducts(string search, int page);
        IEnumerable<Product> GetCategoryProducts(string category, int page);
    }
}