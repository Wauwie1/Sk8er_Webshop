using System;
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
    }
}