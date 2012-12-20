/***************************************************************************\
Module Name:    HotelController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using HotelManagement.Helpers;
using HotelManagement.Web.HotelService;
using HotelManagement.Web.HotelChainService;
using HotelManagement.DTO;

namespace HotelManagement.Controllers
{
    public class HotelController : BaseController
    {
        private IHotelService hotelService;
        private IHotelChainService hotelChainService;

        public HotelController(IHotelService hotelService, IHotelChainService hotelChainService)
        {
            this.hotelService = hotelService;
            this.hotelChainService = hotelChainService;
        }

        //
        // GET: /Hotel/
        // GET: /Hotel/Index
        public ActionResult Index()
        {
            var hotels = hotelService.GetAll();
            ReturnUrlSet();
            return View("Index", hotels);
        }

        //
        // GET: /Hotel/Edit/id
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Edit(int id)
        {
            List<HotelChainDTO> hotelChains = hotelChainService.GetAll().ToList();
            hotelChains.Insert(0, new HotelChainDTO { Id = 0, Name = String.Empty });
            SelectList hotelChainList;

            var hotel = hotelService.GetHotel(id);
                        
            hotelChainList = new SelectList(hotelChains, "Id", "Name", hotel.HotelChain.Id);
            ViewBag.ValidationError = TempData["ValidationError"];            

            ViewBag.HotelChainList = hotelChainList;
            ReturnUrlSet();
            return View("Edit", hotel);
        }

        //
        // GET: /Hotel/Add
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Add(HotelDTO hotel)
        {
            List<HotelChainDTO> hotelChains = hotelChainService.GetAll().ToList();
            hotelChains.Insert(0, new HotelChainDTO { Id = 0, Name = String.Empty });
            SelectList hotelChainList;

            if (hotel == null || TempData["HotelChainSelectedId"] == null)
            {
                hotelChainList = new SelectList(hotelChains, "Id", "Name");
                hotel = new HotelDTO();
            }
            else
            {
                hotelChainList = new SelectList(hotelChains, "Id", "Name", TempData["HotelChainSelectedId"]);
                ViewBag.ValidationError = TempData["ValidationError"];
            }

            ViewBag.HotelChainList = hotelChainList;
            ReturnUrlSet();
            return View("Add", hotel);
        }

        //
        // POST: /Hotel/Create
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Create(HotelDTO hotel)
        {
            string error = ""; // hotelRepository.ValidateSave(hotel);
            ReturnUrlSet();
            if (error.Length == 0)
            {
                hotelService.Save(hotel);
                return RedirectToAction("Success", "Hotel", new { message = "Successfully saved the Hotel." });
            }
            else
            {
                TempData["ValidationError"] = error;
                TempData["HotelChainSelectedId"] = hotel.HotelChain.Id;
                return RedirectToAction("Add", "Hotel", hotel);
            }
        }

        //
        // GET: /Hotel/Sucess
        public ActionResult Success(string message)
        {
            ReturnUrlSet();
            return View("Success", (object)message);
        }

        //
        // POST: /Hotel/Delete/hotel
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Delete(HotelDTO hotel, int? id)
        {
            string error = ""; // hotelRepository.ValidateDelete(hotel);
            ReturnUrlSet();
            if (error.Length == 0)
            {
                hotel = hotelService.GetHotel(hotel.Id);
                hotelService.Delete(hotel);
                return View("Success", (object)"Hotel deleted successfully.");
            }
            else
            {
                return Redirect((string)TempData["ReturnUrl"]);
            }
        }
    }
}
