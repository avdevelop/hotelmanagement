using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using AutoMapper;
using HotelManagement.Models;
using HotelManagement.ServiceApp.DTO;

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

        public IEnumerable<BookingDTO> GetAll()
        {
            IEnumerable<Booking> bookings = bookingRepository.Get().ToList();
            IEnumerable<BookingDTO> a = Mapper.Map<IEnumerable<Booking>, IEnumerable<BookingDTO>>(bookings);
            
            return a;
        }

        public BookingDTO GetBooking(int id)
        {
            return Mapper.Map<Booking, BookingDTO>(bookingRepository.Get(id));
        }

        public void Save(BookingDTO obj)
        {
            bookingRepository.Save(Mapper.Map<BookingDTO, Booking>(obj));
        }

        public void Delete(BookingDTO obj)
        {
            bookingRepository.Delete(Mapper.Map<BookingDTO,Booking>(obj));
        }        
    }
}
