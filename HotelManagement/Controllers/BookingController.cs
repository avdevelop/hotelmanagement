using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        IRepository<Booking> bookingRepository;
        IRepository<BookingDetail> bookingDetailRepository;

        public BookingController(IRepository<Booking> bookingRepository,
            IRepository<BookingDetail> bookingDetailRepository)
        { 
        
        }

        //
        // GET: /Booking/
        // GET: /Booking/Index
        public ActionResult Index()
        {
            return View("Index");
        }
        
        //
        // GET: /AddBooking/        
        public ActionResult AddBooking()
        {
            return View("Index");
        }

        //
        // GET: /AddBooking/        
        public ActionResult DeleteBooking()
        {
            return View("Index");
        }
    }
}
