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
        private IRepository<Room> roomRepository;
        private IRepository<Hotel> hotelRepository;
        private IRepository<RoomType> roomTypeRepository;

        public RoomController(IRepository<Room> roomRepository,
            IRepository<Hotel> hotelRepository,
            IRepository<RoomType> roomTypeRepository)
        {
            this.roomRepository = roomRepository;
            this.hotelRepository = hotelRepository;
            this.roomTypeRepository = roomTypeRepository;
        }
        
        //
        // GET: /Room/
        public ActionResult Index()
        {
            IEnumerable<Room> rooms = roomRepository.Get();
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
                var room = roomRepository.Get(id.Value);

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
            List<Hotel> hotels = hotelRepository.Get().ToList();
            hotels.Insert(0, new Hotel() { Id = 0, Name = String.Empty });
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

            //List<RoomType> roomTypes = roomTypeRepository.Get("Name (MaxOccupants)").ToList();
            List<RoomType> roomTypes = roomTypeRepository.Get().ToList();
            roomTypes.Insert(0, new RoomType() { Id = 0, Name = String.Empty });
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

        //
        // POST: /Room/Create
        public ActionResult Create(Room room)
        {
            string error = ""; // roomRepository.ValidateSave(room);

            if (error.Length == 0)
            {
                roomRepository.SaveOrUpdate(room);
                return RedirectToAction("Success", "Room", new { message = "Successfully saved the Room." });
            }
            else
            {
                TempData["ValidationError"] = error;
                TempData["HotelSelectedId"] = room.Hotel.Id;
                TempData["RoomTypeSelectedId"] = room.RoomType.Id;
                return RedirectToAction("Add", "Room", room);
            }
        }

        //
        // GET: /Room/Sucess
        public ActionResult Success(string message)
        {
            return View("Success", (object)message);
        }

        //
        // POST: /Room/Delete/room
        public ActionResult Delete(Room room, int? id)
        {
            string error = ""; // roomRepository.ValidateDelete(room);

            if (error.Length == 0)
            {
                room = roomRepository.Get(room.Id);
                roomRepository.Delete(room);
                return View("Success", (object)"Room deleted successfully.");
            }
            else
            {
                return Redirect((string)ViewData["DeleteReturn"]);
            }
        }
    }
}