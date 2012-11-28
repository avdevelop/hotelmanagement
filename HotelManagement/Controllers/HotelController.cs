using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;
using System.Collections;

namespace HotelManagement.Controllers
{
    public class HotelController : Controller
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
            var hotels = hotelRepository.Get().OfType<Hotel>();
            ViewData["DeleteReturn"] = HttpContext.Request.UrlReferrer.OriginalString;

            return View(hotels);
        }

        //
        // GET: /Hotel/Edit/id
        public ActionResult Edit(int id)
        {
            var hotel = hotelRepository.Get(id);


            return View(hotel);
        }

        //
        // GET: /Hotel/Add
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

            return View(hotel);
        }

        //
        // POST: /Hotel/Create
        public ActionResult Create(Hotel hotel)
        {
            string error = ""; // hotelRepository.ValidateSave(hotel);

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
            return View("Success", (object)message);
        }

        //
        // POST: /Hotel/Delete/hotel
        public ActionResult Delete(Hotel hotel, int? id)
        {
            string error = ""; // hotelRepository.ValidateDelete(hotel);

            if (error.Length == 0)
            {
                hotel = hotelRepository.Get(hotel.Id);
                hotelRepository.Delete(hotel);
                return View("Success", (object)"Hotel deleted successfully.");
            }
            else
            {
                return Redirect((string)ViewData["DeleteReturn"]);
            }
        }
    }
}
