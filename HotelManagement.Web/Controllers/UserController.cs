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
using HotelManagement.Models;
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Helpers;
using HotelManagement.Repository;

namespace HotelManagement.Controllers
{
    public class UserController : BaseController
    {
        IRepository<User> userRepository;
        IRepository<Menu> menuRepository;
        IRepository<UserMenu> userMenuRepository;

        public UserController(IRepository<User> userRepository,
            IRepository<Menu> menuRepository,
            IRepository<UserMenu> userMenuRepository)
        {
            this.userRepository = userRepository;
            this.menuRepository = menuRepository;
            this.userMenuRepository = userMenuRepository;
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
                ViewBag.AllMenu = menuRepository.Get();
                ViewBag.UserMenu = userMenuRepository.GetByUser(userRepository.GetByEmail(SessionCache.UserEmail));

                return View("Edit", userRepository.Get(SessionCache.UserId.Value));
            }
            else
            {
                return RedirectToAction("InvalidParams", "Home");
            }
        }
    }
}
