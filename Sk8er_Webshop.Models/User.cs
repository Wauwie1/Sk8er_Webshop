namespace Sk8er_Webshop.Models
{
    public class User : IModel
    {
        public int Id { get; set; }

        public int AdressId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public int AuthLevel { get; set; }

    }
}