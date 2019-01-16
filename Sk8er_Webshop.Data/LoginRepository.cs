using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public class LoginRepository
    {
        private readonly ILoginContext _context;

        public LoginRepository(ILoginContext context)
        {
            _context = context;
        }

        public User Login(string username, string password)
        {
           return _context.Login(username, password);
        }

        public Adress GetAdress(int id)
        {
            return _context.GetAdress(id);
        }

        public int SetAdress(string adress, int number, string city, string country, string zipcode)
        {
            return _context.SetAdress(adress, number, city, country, zipcode);
        }

        public bool UserNameAlreadyExists(string username)
        {
            return _context.UserNameAlreadyExists(username);
        }

        public void RegisterUser(string username, string email, string password)
        {
            _context.RegisterUser(username, email, password);
        }
    }
}