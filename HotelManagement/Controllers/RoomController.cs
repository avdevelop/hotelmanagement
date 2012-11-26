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
        private IHotelService hotelService;
        private IRoomTypeService roomTypeService;

        public RoomController(IRoomService roomService,
            IHotelService hotelService,
            IRoomTypeService roomTypeService)
        {
            this.roomService = roomService;
            this.hotelService = hotelService;
            this.roomTypeService = roomTypeService;
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
            IEnumerable<Hotel> hotels = hotelService.Get<Hotel>();
            SelectList hotelList;

            if (room == null || TempData["HotelSelectedId"] == null)
            {
                hotelList = new SelectList(hotels, "Id", "Name");
                room = new Room();
            }
            else
            {
                hotelList = new SelectList(hotels, "Id", "Name", TempData["HotelSelectedId"]);
                ViewBag.ValidationError = TempData["ValidationError"];
            }
            ViewBag.HotelList = hotelList;

            IEnumerable<RoomType> roomTypes = roomTypeService.Get<RoomType>("Name (MaxOccupants)");
            SelectList roomTypeList;
            if (room == null || TempData["RoomTypeSelectedId"] == null)
            {
                roomTypeList = new SelectList(roomTypes, "Id", "Name");
                room = new Room();
            }
            else
            {
                roomTypeList = new SelectList(roomTypes, "Id", "Name", TempData["RoomTypeSelectedId"]);
                ViewBag.ValidationError = TempData["ValidationError"];
            }
            ViewBag.RoomTypeList = roomTypeList;

            return View(room);
        }

    }
}
