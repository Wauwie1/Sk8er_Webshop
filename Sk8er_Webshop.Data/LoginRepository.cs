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
    }
}