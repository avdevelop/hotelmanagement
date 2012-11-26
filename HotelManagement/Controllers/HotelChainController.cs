using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class HotelChainController : Controller
    {
        private IHotelChainService hotelChainService;
        private IHotelService hotelService;

        public HotelChainController(IHotelChainService hotelChainService,
            IHotelService hotelService)
        {
            this.hotelChainService = hotelChainService;
            this.hotelService = hotelService;
        }

        //
        // GET: /HotelChain/

        public ActionResult Index()
        {
            ViewBag.HotelChains = hotelChainService.Get<HotelChain>();
            ViewBag.Hotels = hotelService.Get<Hotel>();            
            return View();
        }
    }
}
