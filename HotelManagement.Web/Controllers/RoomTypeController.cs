/***************************************************************************\
Module Name:    RoomTypeController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class RoomTypeController : BaseController
    {
        //
        // GET: /RoomType/

        public ActionResult Index()
        {
            return View();
        }

    }
}
