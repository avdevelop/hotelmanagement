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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelChainService" in code, svc and config file together.
    public class HotelChainService : IHotelChainService
    {
        private IRepository<HotelChain> hotelChainRepository;

        public HotelChainService(IRepository<HotelChain> hotelChainRepository)
        {
            this.hotelChainRepository = hotelChainRepository;
        }

        public IEnumerable<HotelChainDTO> GetAll()
        {
            IEnumerable<HotelChain> hotelChains = hotelChainRepository.Get().ToList();
            IEnumerable<HotelChainDTO> a = Mapper.Map<IEnumerable<HotelChain>, IEnumerable<HotelChainDTO>>(hotelChains);
            
            return a;
        }

        public HotelChainDTO GetHotelChain(int id)
        {
            return Mapper.Map<HotelChain, HotelChainDTO>(hotelChainRepository.Get(id));
        }

        public void Save(HotelChainDTO obj)
        {
            hotelChainRepository.Save(Mapper.Map<HotelChainDTO, HotelChain>(obj));
        }

        public void Delete(HotelChainDTO obj)
        {
            hotelChainRepository.Delete(Mapper.Map<HotelChainDTO, HotelChain>(obj));
        }
    }
}
