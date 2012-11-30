/***************************************************************************\
Module Name:    LoginController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services.Interfaces;
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Helpers.ModelHelpers;

namespace HotelManagement.Controllers
{
    public class LoginController : Controller
    {
        IRepository<User> userRepository;

        public LoginController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        //
        // GET: /Login/
        public ActionResult Index()
        {

            return View("Index");
        }

        //
        // GET: /Login/DoLogin/email/password
        public ActionResult DoLogin(string email, string password)
        {
            string pass = MiscHelper.EncryptStringAES(password, MiscHelper.AppSetting("SecretEncryptText"));

            User user = userRepository.GetByEmail(email);
            if (user != null && (UserHelper.Login(user, pass) == true || user.Password == String.Empty))
            {
                SessionCache.CreateSession(user.Id, user.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                SessionCache.LoginFailCount++;
                ViewBag.ValidationError = "Login failed.";
            }
            
            return View("Index");
        }

    }
}
