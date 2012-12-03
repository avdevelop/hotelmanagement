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
    public class LoginController : BaseController
    {
        IRepository<User> userRepository;
        IRepository<UserMenu> userMenuRepository;
        IRepository<Menu> menuRepository;

        public LoginController(IRepository<User> userRepository,
            IRepository<UserMenu> userMenuRepository,
            IRepository<Menu> menuRepository)
        {
            this.userRepository = userRepository;
            this.userMenuRepository = userMenuRepository;
            this.menuRepository = menuRepository;
        }

        //
        // GET: /Login/
        // GET: /Login/Index
        public ActionResult Index()
        {
            ReturnUrlSet();
            return View("Index");
        }

        //
        // GET: /Login/Login/
        public ActionResult Login(string email, string password)
        {
            string pass = MiscHelper.Encrypt(password);
            User user = userRepository.GetByEmail(email);
            if (user != null && (UserHelper.Login(user, pass) == true || user.Password == String.Empty))
            {
                List<UserMenu> userMenus = userMenuRepository.GetByUser(user).ToList();
                List<Menu> menus = new List<Menu>();

                foreach (UserMenu userMenu in userMenus)
                {
                    menus.Add(menuRepository.Get().FirstOrDefault(m => m.Id == userMenu.Menu.Id));
                }

                SessionCache.CreateSession(user.Id, 
                    user.Email,
                    menus);

                return Redirect((string)TempData["ReturnUrl"]);
            }
            else
            {
                SessionCache.LoginFailCount++;
                ViewBag.ValidationError = "Login failed.";
            }
            
            return View("Index");
        }

        //
        // GET: /Login/Logout/
        public ActionResult Logout()
        {
            SessionCache.DestroySession();
            return RedirectToAction("Index", "Home");            
        }

    }
}
