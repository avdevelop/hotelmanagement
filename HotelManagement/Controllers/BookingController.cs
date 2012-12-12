using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Repositories;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;
using HotelManagement.Helpers;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        IRepository<Booking> bookingRepository;
        IRepository<BookingDetail> bookingDetailRepository;
        IRepository<Room> roomRepository;

        public BookingController(IRepository<Booking> bookingRepository,
            IRepository<BookingDetail> bookingDetailRepository,
            IRepository<Room> roomRepository)
        {
            this.bookingRepository = bookingRepository;
            this.bookingDetailRepository = bookingDetailRepository;
            this.roomRepository = roomRepository;
        }

        //
        // GET: /Booking/
        // GET: /Booking/Index
        public ActionResult Index()
        {
            return View("Index");
        }
        
        //
        // GET: /Booking/AddBooking/        
        public ActionResult AddBooking()
        {
            return View("Index");
        }

        //
        // GET: /Booking/DeleteBooking/        
        public ActionResult DeleteBooking()
        {
            return View("Index");
        }

        //
        // GET: /Booking/CheckAvailability
        public ActionResult CheckAvailability(string arrivalDate, string departureDate, int persons)
        {
            IEnumerable<Room> rooms = roomRepository.Get().Where(r => r.RoomType.MaxOccupants <= persons);
            IEnumerable<BookingDetail> bookingDetails = bookingDetailRepository.Get().Where(bd => bd.Date >= DateTime.Parse(arrivalDate) && bd.Date <= DateTime.Parse(departureDate));

            rooms = rooms.Where(r => ! bookingDetails.Any(b => b.Room.Id == r.Id));

            return View("Availability", rooms);
        }

        public string BookingMonths()
        {
            List<string> months = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                months.Add(DateTime.Now.AddMonths(i).ToString("MMM") + " " + DateTime.Now.AddMonths(i).ToString("yyyy"));
            }

            return MiscHelper.ToJson(months);
        }

        public string BookingDays(string month)
        {
            string year = month.Split(" ".ToCharArray())[1];
            month = month.Split(" ".ToCharArray())[0];
            List<int> days = new List<int>();

            for (int i = 1; i <= DateTime.DaysInMonth(int.Parse(year), MiscHelper.GetMonth(month)); i++)
            {
                days.Add(i);
            }

            return MiscHelper.ToJson(days);
        }
    }
}
