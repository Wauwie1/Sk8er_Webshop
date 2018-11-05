using System.Collections.Generic;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
        public Product Product { get; set; }
    }
}