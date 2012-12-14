using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using HotelManagement.Models;

namespace HotelManagement.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookingService" in both code and config file together.
    public class BookingService : IBookingService
    {
        private IRepository<Booking> bookingRepository;

        public BookingService(IRepository<Booking> bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetAll()
        {
            return bookingRepository.Get();
        }
        
        public Booking GetBooking(int id)
        {
            return bookingRepository.Get(id);
        }

        public void Save(Booking obj)
        {
            bookingRepository.Save(obj);
        }

        public void Delete(Booking obj)
        {
            bookingRepository.Delete(obj);
        }
    }
}
