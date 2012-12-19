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
using HotelManagement.Helpers;
using HotelManagement.Web.UserMenuService;

namespace HotelManagement.Controllers
{
    public class HomeController : BaseController
    {
        IUserMenuService userMenuService;

        public HomeController(IUserMenuService userMenuService)
        {
            this.userMenuService = userMenuService;
        }

        //
        // GET: /Home/
        // GET: /Home/Index        
        public ActionResult Index()
        {
            List<UserMenuDTO> menuItems = userMenuService.GetAll().ToList();
            string s = menuItems[0].UserDTO.Email;
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
