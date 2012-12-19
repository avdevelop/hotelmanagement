using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using HotelManagement.Models;
using AutoMapper;
using HotelManagement.ServiceApp.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    public class HotelService : IHotelService
    {
        private IRepository<Hotel> hotelRepository;

        public HotelService(IRepository<Hotel> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public IEnumerable<HotelDTO> GetAll()
        {
            IEnumerable<Hotel> hotels = hotelRepository.Get().ToList();
            IEnumerable<HotelDTO> a = Mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
            
            return a;
        }

        public HotelDTO GetHotel(int id)
        {
            return Mapper.Map<Hotel, HotelDTO>(hotelRepository.Get(id));
        }

        public void Save(HotelDTO obj)
        {
            hotelRepository.Save(Mapper.Map<HotelDTO, Hotel>(obj));
        }

        public void Delete(HotelDTO obj)
        {
            hotelRepository.Delete(Mapper.Map<HotelDTO, Hotel>(obj));
        }
    }
}
