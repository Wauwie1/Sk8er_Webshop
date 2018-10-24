using System;

namespace Sk8er_Webshop.Models
{
    public class Product : AbstractModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Collection { get; set; }

        public string ProductType { get; set; }

        public string ImgURL { get; set; }

        public Stock Stock { get; set; }

    }
}
