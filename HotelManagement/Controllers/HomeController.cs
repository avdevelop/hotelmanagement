using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        // GET: /Home/Index

        public ActionResult Index()
        {
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
