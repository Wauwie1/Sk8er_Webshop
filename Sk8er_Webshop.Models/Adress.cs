namespace Sk8er_Webshop.Models
{
    public class Adress : IModel
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string HouseAddition { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
    }
}