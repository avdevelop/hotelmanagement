/***************************************************************************\
Module Name:    RoomController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Helpers;
using HotelManagement.Web.RoomService;
using HotelManagement.Web.HotelService;
using HotelManagement.Web.RoomTypeService;
using HotelManagement.Web.UserTypeService;

namespace HotelManagement.Controllers
{
    public class RoomController : BaseController
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
            IEnumerable<RoomDTO> rooms = roomService.GetAll();
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
                var room = roomService.GetRoom(id.Value);

                if (room == null)
                {
                    return RedirectToAction("InvalidParams", "Home");
                }

                return View(room);
            }
        }

        //
        // GET: /Room/Add
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Add(RoomDTO room)
        {
            List<HotelManagement.Web.HotelService.HotelDTO> hotels = hotelService.GetAll().ToList();
            hotels.Insert(0, new HotelManagement.Web.HotelService.HotelDTO() { Id = 0, Name = String.Empty });
            SelectList hotelList;

            if (room == null || TempData["HotelSelectedId"] == null)
            {
                hotelList = new SelectList(hotels, "Id", "Name");
                room = new RoomDTO();
            }
            else
            {
                hotelList = new SelectList(hotels, "Id", "Name", TempData["HotelSelectedId"]);
                ViewBag.ValidationError = TempData["ValidationError"];
            }
            ViewBag.HotelList = hotelList;

            //List<RoomType> roomTypes = roomTypeRepository.Get("Name (MaxOccupants)").ToList();
            List<HotelManagement.Web.RoomTypeService.RoomTypeDTO> roomTypes = roomTypeService.GetAll().ToList();
            roomTypes.Insert(0, new HotelManagement.Web.RoomTypeService.RoomTypeDTO() { Id = 0, Name = String.Empty });
            SelectList roomTypeList;
            if (room == null || TempData["RoomTypeSelectedId"] == null)
            {
                roomTypeList = new SelectList(roomTypes, "Id", "Name");
                room = new RoomDTO();
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
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Create(RoomDTO room)
        {
            string error = ""; // roomRepository.ValidateSave(room);

            if (error.Length == 0)
            {
                roomService.Save(room);
                return RedirectToAction("Success", "Room", new { message = "Successfully saved the Room." });
            }
            else
            {
                TempData["ValidationError"] = error;
                TempData["HotelSelectedId"] = room.HotelDTO.Id;
                TempData["RoomTypeSelectedId"] = room.RoomTypeDTO.Id;
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
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Delete(RoomDTO room, int? id)
        {
            string error = ""; // roomRepository.ValidateDelete(room);

            if (error.Length == 0)
            {
                room = roomService.GetRoom(room.Id);
                roomService.Delete(room);
                return View("Success", (object)"Room deleted successfully.");
            }
            else
            {
                return Redirect((string)ViewData["DeleteReturn"]);
            }
        }
    }
}