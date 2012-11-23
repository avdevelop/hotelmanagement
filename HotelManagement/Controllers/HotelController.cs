using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class HotelController : Controller
    {
        private IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            var hotels = hotelService.Get<Hotel>().OfType<Hotel>();


            return View(hotels);
        }

        //
        // GET: /Hotel/

        public ActionResult Edit(int id)
        {
            var hotel = hotelService.Get<Hotel>(id);


            return View(hotel);
        }

    }
}
