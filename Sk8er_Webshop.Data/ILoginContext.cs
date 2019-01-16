
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Data
{
    public interface ILoginContext
    {
        User Login(string username, string password);
        Adress GetAdress(int id);
        int SetAdress(string adress, int number, string city, string country, string zipcode);
        bool UserNameAlreadyExists(string username);
        void RegisterUser(string username, string email, string password);
    }
}