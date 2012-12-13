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
using HotelManagement.Repositories;
using HotelManagement.Models;
using System.Collections;
using HotelManagement.Repositories.Interfaces;
using HotelManagement.Helpers;

namespace HotelManagement.Controllers
{
    public class HotelController : BaseController
    {
        private IRepository<Hotel> hotelRepository;
        private IRepository<HotelChain> hotelChainRepository;

        public HotelController(IRepository<Hotel> hotelRepository, IRepository<HotelChain> hotelChainRepository)
        {
            this.hotelRepository = hotelRepository;
            this.hotelChainRepository = hotelChainRepository;
        }

        //
        // GET: /Hotel/
        // GET: /Hotel/Index
        public ActionResult Index()
        {
            var hotels = hotelRepository.Get();
            ReturnUrlSet();
            return View("Index", hotels);
        }

        //
        // GET: /Hotel/Edit/id
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Edit(int id)
        {
            List<HotelChain> hotelChains = hotelChainRepository.Get().ToList();
            hotelChains.Insert(0, new HotelChain { Id = 0, Name = String.Empty });
            SelectList hotelChainList;

            var hotel = hotelRepository.Get(id);
                        
            hotelChainList = new SelectList(hotelChains, "Id", "Name", hotel.HotelChain.Id);
            ViewBag.ValidationError = TempData["ValidationError"];            

            ViewBag.HotelChainList = hotelChainList;
            ReturnUrlSet();
            return View("Edit", hotel);
        }

        //
        // GET: /Hotel/Add
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Add(Hotel hotel)
        {
            List<HotelChain> hotelChains = hotelChainRepository.Get().ToList();
            hotelChains.Insert(0, new HotelChain { Id = 0, Name = String.Empty });
            SelectList hotelChainList;

            if (hotel == null || TempData["HotelChainSelectedId"] == null)
            {
                hotelChainList = new SelectList(hotelChains, "Id", "Name");
                hotel = new Hotel();
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
        public ActionResult Create(Hotel hotel)
        {
            string error = ""; // hotelRepository.ValidateSave(hotel);
            ReturnUrlSet();
            if (error.Length == 0)
            {
                hotelRepository.SaveOrUpdate(hotel);
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
        public ActionResult Delete(Hotel hotel, int? id)
        {
            string error = ""; // hotelRepository.ValidateDelete(hotel);
            ReturnUrlSet();
            if (error.Length == 0)
            {
                hotel = hotelRepository.Get(hotel.Id);
                hotelRepository.Delete(hotel);
                return View("Success", (object)"Hotel deleted successfully.");
            }
            else
            {
                return Redirect((string)TempData["ReturnUrl"]);
            }
        }
    }
}
