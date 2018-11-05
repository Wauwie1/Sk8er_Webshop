using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface IContext<T> where T : IModel
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}