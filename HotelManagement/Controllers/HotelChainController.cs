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
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class HotelChainController : BaseController
    {
        readonly private IRepository<HotelChain> hotelChainRepository;
        readonly private IRepository<Hotel> hotelRepository;

        public HotelChainController(IRepository<HotelChain> hotelChainRepository,
            IRepository<Hotel> hotelRepository)
        {
            this.hotelChainRepository = hotelChainRepository;
            this.hotelRepository = hotelRepository;
        }

        //
        // GET: /HotelChain/

        public ActionResult Index()
        {
            ViewBag.HotelChains = hotelChainRepository.Get();
            ViewBag.Hotels = hotelRepository.Get();
            return View();
        }
    }
}
