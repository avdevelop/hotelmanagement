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
            var hotels = hotelService.Get<Hotel>().OfType<Hotel>();


            return View(hotels);
        }

        //
        // GET: /Hotel/Edit/id
        public ActionResult Edit(int id)
        {
            var hotel = hotelService.Get<Hotel>(id);


            return View(hotel);
        }

        //
        // GET: /Hotel/Add
        public ActionResult Add(Hotel hotel)
        {   
            IEnumerable<HotelChain> hotelChains = hotelService.Get<HotelChain>();
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
            string error = hotelService.Validate(hotel);

            if (error.Length == 0)
            {
                hotelService.SaveOrUpdate<Hotel>(hotel);
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
    }
}
