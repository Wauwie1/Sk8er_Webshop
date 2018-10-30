using System.Collections.Generic;

namespace Sk8er_Webshop.Models
{
    public class Stock : IModel
    {
        public int Id { get; set; }
        public int ProductKey { get; set; }

        public string ProductName { get; set; }

        public List<Size> Sizes { get; set; }
    }
}