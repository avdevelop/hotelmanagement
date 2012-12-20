using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using HotelManagement.DTO;
using HotelManagement.Models;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomService" in code, svc and config file together.
    public class RoomService : IRoomService
    {
        private IRepository<Room> roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            IEnumerable<Room> rooms = roomRepository.Get().ToList();
            IEnumerable<RoomDTO> a = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(rooms);
            
            return a;
        }

        public RoomDTO GetRoom(int id)
        {
            return Mapper.Map<Room, RoomDTO>(roomRepository.Get(id));
        }

        public void Save(RoomDTO obj)
        {
            roomRepository.Save(Mapper.Map<RoomDTO, Room>(obj));
        }

        public void Delete(RoomDTO obj)
        {
            roomRepository.Delete(Mapper.Map<RoomDTO, Room>(obj));
        }
    }
}
