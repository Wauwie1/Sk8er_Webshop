using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface IProductContext<T> where T : IModel
    {
        T GetById(int id);
        IEnumerable<T> GetAll(int page);
        IEnumerable<T> GetSearchedProducts(string search, int page);
        IEnumerable<T> GetCategoryProducts(string category, int page);
        bool AddNewProduct(string name, string description, decimal price, string collection, string productType,
            string ImgUrl);
    }

}