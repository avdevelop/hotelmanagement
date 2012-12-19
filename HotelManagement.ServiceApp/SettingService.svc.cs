using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.ServiceApp.DTO;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SettingService" in code, svc and config file together.
    public class SettingService : ISettingService
    {
         private IRepository<Setting> roomRepository;

        public SettingService(IRepository<Setting> roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public IEnumerable<SettingDTO> GetAll()
        {
            IEnumerable<Setting> rooms = roomRepository.Get().ToList();
            IEnumerable<SettingDTO> a = Mapper.Map<IEnumerable<Setting>, IEnumerable<SettingDTO>>(rooms);
            
            return a;
        }

        public SettingDTO GetSetting(int id)
        {
            return Mapper.Map<Setting, SettingDTO>(roomRepository.Get(id));
        }

        public void Save(SettingDTO obj)
        {
            roomRepository.Save(Mapper.Map<SettingDTO, Setting>(obj));
        }

        public void Delete(SettingDTO obj)
        {
            roomRepository.Delete(Mapper.Map<SettingDTO, Setting>(obj));
        }
    }
}
