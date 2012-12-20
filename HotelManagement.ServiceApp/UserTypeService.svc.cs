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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserTypeService" in code, svc and config file together.
    public class UserTypeService : IUserTypeService
    {
        private IRepository<UserType> userTypeRepository;

        public UserTypeService(IRepository<UserType> userTypeRepository)
        {
            this.userTypeRepository = userTypeRepository;
        }

        public IEnumerable<UserTypeDTO> GetAll()
        {
            IEnumerable<UserType> userTypes = userTypeRepository.Get().ToList();
            IEnumerable<UserTypeDTO> a = Mapper.Map<IEnumerable<UserType>, IEnumerable<UserTypeDTO>>(userTypes);
            
            return a;
        }

        public UserTypeDTO GetUserType(int id)
        {
            return Mapper.Map<UserType, UserTypeDTO>(userTypeRepository.Get(id));
        }

        public void Save(UserTypeDTO obj)
        {
            userTypeRepository.Save(Mapper.Map<UserTypeDTO, UserType>(obj));
        }

        public void Delete(UserTypeDTO obj)
        {
            userTypeRepository.Delete(Mapper.Map<UserTypeDTO, UserType>(obj));
        }

        public UserTypeEnum UserType(int id)
        { 
            switch(id)
            {
                case 1:
                    return UserTypeEnum.Admin;
                case 2:
                    return UserTypeEnum.Normal;
                default:
                    return UserTypeEnum.Normal;
            }
        }
    }
}
