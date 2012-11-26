using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        IUserMenuService menuService;

        public HomeController(IUserMenuService menuService)
        {
            this.menuService = menuService;
        }

        //
        // GET: /Home/
        // GET: /Home/Index
        public ActionResult Index()
        {
            List<UserMenu> menuItems =  menuService.Get<UserMenu>().ToList();
            string s = menuItems[0].User.Email;
            return View();
        }

        //
        // GET: /Home/InvalidParams

        public ActionResult InvalidParams()
        {
            return View();
        }
    }
}
