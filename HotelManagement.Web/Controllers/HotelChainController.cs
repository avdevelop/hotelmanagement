/***************************************************************************\
Module Name:    HotelChainController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Web.HotelChainService;
using HotelManagement.Web.HotelService;

namespace HotelManagement.Controllers
{
    public class HotelChainController : BaseController
    {
        readonly private IHotelChainService hotelChainService;
        readonly private IHotelService hotelService;

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
            ViewBag.HotelChains = hotelChainService.GetAll();
            ViewBag.Hotels = hotelService.GetAll();
            return View();
        }
    }
}
