using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sk8er_Webshop.Logic;
using Sk8er_Webshop.Models;
using Sk8er_Webshop.ViewModels;
namespace Sk8er_Webshop.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginLogic logic = new LoginLogic();
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
            string test = HttpContext.Session.GetString("User");
            return Content(test);
        }

        public IActionResult LoginFailed()
        {
            throw new NotImplementedException();
        }
    }
}