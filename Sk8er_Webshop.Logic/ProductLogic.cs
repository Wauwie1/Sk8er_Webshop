using System;
using System.Collections.Generic;
using System.Text;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public static class ProductLogic
    {
        public static Product GetProductById(int id)
        {
           
            Product product;
            product = ProductData.GetProductById(id);
            return product;
           
        }
    }
}
