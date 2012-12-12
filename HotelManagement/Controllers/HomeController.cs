/***************************************************************************\
Module Name:    HomeController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Repositories;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;

namespace HotelManagement.Controllers
{
    public class HomeController : BaseController
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

        public string TestMessage(string name, int id)
        {
            if (name.Length > 0 && id > 0)
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            }            
        }
    }
}
