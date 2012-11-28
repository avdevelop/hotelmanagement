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
        IRepository<UserMenu> userMenuRepository;

        public HomeController(IRepository<UserMenu> userMenuRepository)
        {
            this.userMenuRepository = userMenuRepository;
        }

        //
        // GET: /Home/
        // GET: /Home/Index
        public ActionResult Index()
        {
            List<UserMenu> menuItems = userMenuRepository.Get().ToList();
            string s = menuItems[0].User.Email;
            return View("Index");
        }

        //
        // GET: /Home/InvalidParams

        public ActionResult InvalidParams()
        {
            return View("InvalidParams");
        }
    }
}
