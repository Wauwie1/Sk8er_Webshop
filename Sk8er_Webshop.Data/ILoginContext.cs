using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface ILoginContext
    {
        User Login(string username, string password);
        Adress GetAdress(int id);
    }
}