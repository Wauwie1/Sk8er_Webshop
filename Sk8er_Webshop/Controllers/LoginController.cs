using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sk8er_Webshop.Data;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.ViewModels;
namespace Sk8er_Webshop.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginLogic logic;

        public LoginController(IConfiguration configuration)
        {
            logic = new LoginLogic(new LoginSQLContext(configuration));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            User user = logic.Login(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                return RedirectToAction("Userpage");
            }
            else
            {
                return RedirectToAction("LoginFailed");
            }
        }

        public IActionResult Userpage()
        {
            string userString = HttpContext.Session.GetString("User");
            UserViewModel viewModel = new UserViewModel()
            {
                CurrentUser = logic.GetUser(userString)
            };
            return View(viewModel);
        }

        public IActionResult LoginFailed()
        {
            throw new NotImplementedException();
        }

        public IActionResult Adress()
        {
            string userString = HttpContext.Session.GetString("User");
            User user = logic.GetUser(userString);

            UserViewModel viewModel = new UserViewModel()
            {
                CurrentUser = user,
                UserAdress = logic.GetAdress(user.AdressId)
            };
            return View(viewModel);
        }
    }
}