/***************************************************************************\
Module Name:    UserController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Helpers;
using HotelManagement.Web.UserTypeService;
using HotelManagement.Web.UserMenuService;
using HotelManagement.Web.MenuService;
using HotelManagement.Web.UserService;
using HotelManagement.DTO;

namespace HotelManagement.Controllers
{
    public class UserController : BaseController
    {
        IUserService userService;
        IMenuService menuService;
        IUserMenuService userMenuService;

        public UserController(IUserService userService,
            IMenuService menuService,
            IUserMenuService userMenuService)
        {
            this.userService = userService;
            this.menuService = menuService;
            this.userMenuService = userMenuService;
        }

        //
        // GET: /User/
        // GET: /User/Index
        public ActionResult Index()
        {
            ReturnUrlSet();
            return View("Index");
        }

        //
        // GET: /User/Edit
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Edit()
        {
            ReturnUrlSet();
            if (SessionCache.UserId.HasValue)
            {
                ViewBag.AllMenu = menuService.GetAll();
                ViewBag.UserMenu = userMenuService.GetByUser(userService.GetByEmail(SessionCache.UserEmail).Id);

                return View("Edit", userService.GetUser(SessionCache.UserId.Value));
            }
            else
            {
                return RedirectToAction("InvalidParams", "Home");
            }
        }
    }
}
