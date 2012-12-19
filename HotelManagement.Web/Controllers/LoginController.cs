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
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Helpers.ModelHelpers;
using HotelManagement.Web.UserService;
using HotelManagement.Web.UserMenuService;
using HotelManagement.Web.MenuService;
using HotelManagement.Web.UserTypeService;

namespace HotelManagement.Controllers
{
    public class LoginController : BaseController
    {
        IUserService userService;
        IUserMenuService userMenuService;
        IMenuService menuService;

        public LoginController(IUserService userService,
            IUserMenuService userMenuService,
            IMenuService menuService)
        {
            this.userService = userService;
            this.userMenuService = userMenuService;
            this.menuService = menuService;
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
            HotelManagement.Web.UserService.UserDTO user = userService.GetByEmail(email);
            if (user != null && (UserHelper.Login(user, pass) == true || user.Password == String.Empty))
            {
                List<UserMenuDTO> userMenus = userMenuService.GetByUser(user.Id).ToList();
                List<HotelManagement.Web.MenuService.MenuDTO> menus = new List<HotelManagement.Web.MenuService.MenuDTO>();

                foreach (UserMenuDTO userMenu in userMenus)
                {
                    menus.Add(menuService.GetAll().FirstOrDefault(m => m.Id == userMenu.MenuDTO.Id));
                }

                SessionCache.CreateSession(user.Id, 
                    user.Email,
                    menus,                    
                    user.UserTypeDTO);

                if (TempData["ReturnUrl"] == null || String.IsNullOrEmpty((string)TempData["ReturnUrl"]))
                {
                    return Redirect("/Home/");
                }
                else
                {
                    return Redirect((string)TempData["ReturnUrl"]);
                }                
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
        [Authenticate(UserTypeEnum.Admin, UserTypeEnum.Normal)]
        public ActionResult Logout()
        {
            SessionCache.DestroySession();
            return RedirectToAction("Index", "Home");            
        }

    }
}
