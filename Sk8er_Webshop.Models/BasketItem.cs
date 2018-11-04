using System;
using System.Collections.Generic;
using System.Text;

namespace Sk8er_Webshop.Models
{
    public class BasketItem : IModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public string Size { get; set; }

        public Product Product { get; set; }
    }
}
