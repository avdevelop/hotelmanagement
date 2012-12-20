using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Models;
using HotelManagement.DTO;
using HotelManagement.Repository;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomTypeService" in code, svc and config file together.
    public class RoomTypeService : IRoomTypeService
    {
        private IRepository<RoomType> roomTypeRepository;

        public RoomTypeService(IRepository<RoomType> roomTypeRepository)
        {
            this.roomTypeRepository = roomTypeRepository;
        }

        public IEnumerable<RoomTypeDTO> GetAll()
        {
            IEnumerable<RoomType> roomTypes = roomTypeRepository.Get().ToList();
            IEnumerable<RoomTypeDTO> a = Mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeDTO>>(roomTypes);
            
            return a;
        }

        public RoomTypeDTO GetRoom(int id)
        {
            return Mapper.Map<RoomType, RoomTypeDTO>(roomTypeRepository.Get(id));
        }

        public void Save(RoomTypeDTO obj)
        {
            roomTypeRepository.Save(Mapper.Map<RoomTypeDTO, RoomType>(obj));
        }

        public void Delete(RoomTypeDTO obj)
        {
            roomTypeRepository.Delete(Mapper.Map<RoomTypeDTO, RoomType>(obj));
        }
    }
}
