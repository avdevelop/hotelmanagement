using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using HotelManagement.Models;
using HotelManagement.ServiceApp.DTO;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookingDetailService" in code, svc and config file together.
    public class BookingDetailService : IBookingDetailService
    {
        private IRepository<BookingDetail> bookingDetailRepository;

        public BookingDetailService(IRepository<BookingDetail> bookingDetailRepository)
        {
            this.bookingDetailRepository = bookingDetailRepository;
        }

        public IEnumerable<BookingDetailDTO> GetAll()
        {
            IEnumerable<BookingDetail> bookingDetails = bookingDetailRepository.Get().ToList();
            IEnumerable<BookingDetailDTO> a = Mapper.Map<IEnumerable<BookingDetail>, IEnumerable<BookingDetailDTO>>(bookingDetails);
            
            return a;
        }

        public BookingDetailDTO GetBookingDetail(int id)
        {
            return Mapper.Map<BookingDetail, BookingDetailDTO>(bookingDetailRepository.Get(id));
        }

        public void Save(BookingDetailDTO obj)
        {
            bookingDetailRepository.Save(Mapper.Map<BookingDetailDTO, BookingDetail>(obj));
        }

        public void Delete(BookingDetailDTO obj)
        {
            bookingDetailRepository.Delete(Mapper.Map<BookingDetailDTO,BookingDetail>(obj));
        }
    }
}
