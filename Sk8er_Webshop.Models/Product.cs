using System;

namespace Sk8er_Webshop.Models
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Collection { get; set; }

        public string ProductType { get; set; }

        public string ImgUrl { get; set; }

        public Stock Stock { get; set; }

    }
}
