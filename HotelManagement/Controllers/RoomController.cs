using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }


        //
        // GET: /Room/

        public ActionResult Index()
        {
            var room = roomService.Get<Room>();
            return View();
        }

        //
        // GET: /Room/

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("InvalidParams", "Home");
            }
            else
            {
                var room = roomService.Get<Room>(id.Value);

                if (room == null)
                {
                    return RedirectToAction("InvalidParams", "Home");
                }

                return View(room);
            }
        }

    }
}
