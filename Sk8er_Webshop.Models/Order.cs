namespace Sk8er_Webshop.Models
{
    public class Order : IModel
    {
        public int Id { get; set; }
        public string ProductsJSON { get; set; }
        public int UserKey { get; set; }
        public Status Status { get; set; }
        public decimal TotalPrice { get; set; }

    }

    public enum Status
    {
        Received,
        Processing,
        Shipped,
        Arrived,
        Cancelled,

    }
}