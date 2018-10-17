using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public static class ProductData
    {
        public static Product GetProductById(int id)
        {
            return new Product{Name = "TEST", ImgURL = "https://cdn.webshopapp.com/shops/260322/files/222595769/patagonia-patagonia-retro-pile-vest-el-cap-khaki-2.jpg" };
        }
    }
}