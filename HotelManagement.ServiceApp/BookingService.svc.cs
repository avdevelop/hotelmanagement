using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookingService" in code, svc and config file together.
    public class BookingService : IBookingService
    {
        private IRepository<Booking> bookingRepository;

        public BookingService(IRepository<Booking> bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public List<A> GetAll1()
        {
            List<A> a = new List<A>();
            a.Add(new A() { id = 1, name = "sdasdsd", b = new B() { mem1 = 11, mem2 = "666"  } });
            a.Add(new A() { id = 2, name = "ggggg", b = new B() { mem1 = 123, mem2 = "77777" } });
            a.Add(new A() { id = 3, name = "5555555", b = new B() { mem1 = 1556, mem2 = "88974" } });
            return  a;
        }

        public IEnumerable<HotelManagement.ServiceApp.DTO.Booking> GetAll()
        {
            IEnumerable<Booking> bookings = bookingRepository.Get().ToList();
            IEnumerable<HotelManagement.ServiceApp.DTO.Booking> a = Mapper.Map<IEnumerable<Booking>, IEnumerable<HotelManagement.ServiceApp.DTO.Booking>>(bookings);
            
            return a;
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
