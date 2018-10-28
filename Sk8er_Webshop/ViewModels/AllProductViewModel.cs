using Sk8er_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8er_Webshop.ViewModels
{
    public class AllProductViewModel
    {
        public int Page { get; set; }
        public int NextPage
        {
            get => Page + 1;
            set => NextPage = value;
        }
        public int PrevPage
        {
            get => Page - 1;
            set => PrevPage = value;
        }
        public string Search { get; set; }

        public string Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
