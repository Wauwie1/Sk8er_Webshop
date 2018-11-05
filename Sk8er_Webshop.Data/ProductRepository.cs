using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class ProductRepository
    {
        private IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return context.GetById(id);
        }
    }
}