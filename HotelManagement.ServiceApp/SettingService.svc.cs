using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.DTO;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SettingService" in code, svc and config file together.
    public class SettingService : ISettingService
    {
         private IRepository<Setting> settingRepository;

         public SettingService(IRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        public IEnumerable<SettingDTO> GetAll()
        {
            IEnumerable<Setting> settings = settingRepository.Get().ToList();
            IEnumerable<SettingDTO> a = Mapper.Map<IEnumerable<Setting>, IEnumerable<SettingDTO>>(settings);
            
            return a;
        }

        public SettingDTO GetSetting(int id)
        {
            return Mapper.Map<Setting, SettingDTO>(settingRepository.Get(id));
        }

        public void Save(SettingDTO obj)
        {
            settingRepository.Save(Mapper.Map<SettingDTO, Setting>(obj));
        }

        public void Delete(SettingDTO obj)
        {
            settingRepository.Delete(Mapper.Map<SettingDTO, Setting>(obj));
        }

        public SettingDTO GetByName(string name)
        {
            return Mapper.Map<Setting, SettingDTO>(settingRepository.Get().FirstOrDefault(s => String.Compare(s.Name, name, true) == 0));
        }
    }
}
