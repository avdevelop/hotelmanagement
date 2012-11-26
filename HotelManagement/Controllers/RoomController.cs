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
            IEnumerable<Room> rooms = roomService.Get<Room>();
            return View(rooms);
        }

        //
        // GET: /Room/Detail/id
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

        //
        // GET: /Room/Add
        public ActionResult Add(Room room)
        {            
            if (room == null || room.Id == 0)
            {                
                room = new Room();
            }
            else
            {                
                ViewBag.ValidationError = TempData["ValidationError"];
            }
            
            return View(room);
        }

    }
}
