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
        private readonly LoginLogic _logic;

        public LoginController(IConfiguration configuration)
        {
            _logic = new LoginLogic(new LoginSqlContext(configuration));
        }
        public IActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Userpage");
            }

        }

        public IActionResult Login(string username, string password)
        {

            User user = _logic.Login(username, password);
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

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterUser(string username, string email, string password)
        {
            if (!_logic.UserNameExists(username))
            {
                _logic.RegisterUser(username, email, password);
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Username already exists.");
            }
        }

        public IActionResult Userpage()
        {
            string userString = HttpContext.Session.GetString("User");
            UserViewModel viewModel = new UserViewModel()
            {
                CurrentUser = _logic.GetUser(userString)
            };
            return View(viewModel);
        }

        public IActionResult LoginFailed()
        {
            return Content("Login failed");
        }

        public IActionResult Adress()
        {
            string userString = HttpContext.Session.GetString("User");
            User user = _logic.GetUser(userString);

            UserViewModel viewModel = new UserViewModel()
            {
                CurrentUser = user,
                UserAdress = _logic.GetAdress(user.AdressId)
            };
            return View(viewModel);
        }
    }
}