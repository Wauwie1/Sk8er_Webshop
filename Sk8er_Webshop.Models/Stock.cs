using System.Collections.Generic;

namespace Sk8er_Webshop.Models
{
    public class Stock : AbstractModel
    {
        public int ProductKey { get; set; }

        public List<Size> Sizes { get; set; }
    }
}