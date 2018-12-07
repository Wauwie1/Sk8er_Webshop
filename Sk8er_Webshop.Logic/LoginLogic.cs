using System;
using System.Linq;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class LoginLogic
    {
        private readonly LoginRepository repository;

        public LoginLogic()
        {
            repository = new LoginRepository(new LoginSQLContext());
        }
        public User Login(string username, string password)
        {
            return repository.Login(username, password);
        }

        public User GetUser(string userString)
        {
            var user = new User();
            user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }

        public Adress GetAdress(int id)
        {
            return repository.GetAdress(id);
        }
    }
}