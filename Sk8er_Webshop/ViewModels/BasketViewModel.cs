using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItem> BasketItems { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal sum = 0;
                foreach (var item in BasketItems)
                {
                    sum += item.Product.Price * item.Amount;
                }
                return sum;
            }
            
        }
        public Product Product { get; set; }
    }
}