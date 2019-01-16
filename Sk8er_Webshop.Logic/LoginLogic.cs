using System;
using System.Linq;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Models;

namespace Sk8er_Webshop.Logic
{
    public class LoginLogic
    {
        private readonly LoginRepository _repository;

        public LoginLogic(ILoginContext context)
        {
            _repository = new LoginRepository(context);
        }
        public User Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

        public User GetUser(string userString)
        {
            var user = new User();
            user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }

        public Adress GetAdress(int id)
        {
            return _repository.GetAdress(id);
        }

        public int SetAdress(string adress, int number, string city, string country, string zipcode)
        {
           return _repository.SetAdress(adress, number, city, country, zipcode);
        }

        public void RegisterUser(string username, string email, string password)
        {

           _repository.RegisterUser(username, email, password);
        }

        public bool UserNameExists(string username)
        {
            return _repository.UserNameAlreadyExists(username);
        }
    }
}