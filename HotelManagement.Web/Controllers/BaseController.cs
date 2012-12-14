using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        private ActionResult Index()
        {
            return View();
        }

        public void ReturnUrlSet()
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                TempData["ReturnUrl"] = HttpContext.Request.UrlReferrer.OriginalString;
            }
            else
            {
                TempData["ReturnUrl"] = String.Empty;
            }
        }

        public bool RequestValid()
        {
            return true;
        }
    }
}
