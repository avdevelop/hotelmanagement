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

        public HotelChainController(IHotelChainService service)
        {
            this.hotelChainService = service;
        }

        //
        // GET: /HotelChain/

        public ActionResult Index()
        {
            ViewBag.HotelChains = hotelChainService.GetAll<HotelChain>();
            return View();
        }

    }
}
