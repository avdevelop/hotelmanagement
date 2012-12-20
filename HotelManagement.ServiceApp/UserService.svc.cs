using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Repository;
using HotelManagement.Models;
using HotelManagement.DTO;
using AutoMapper;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<User> users = userRepository.Get().ToList();
            IEnumerable<UserDTO> a = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            
            return a;
        }

        public UserDTO GetUser(int id)
        {
            return Mapper.Map<User, UserDTO>(userRepository.Get(id));
        }

        public void Save(UserDTO obj)
        {
            userRepository.Save(Mapper.Map<UserDTO, User>(obj));
        }

        public void Delete(UserDTO obj)
        {
            userRepository.Delete(Mapper.Map<UserDTO, User>(obj));
        }

        public UserDTO GetByEmail(string email)
        {
            return Mapper.Map<User, UserDTO>(userRepository.Get().FirstOrDefault(u => u.Email == email));
        }
    }
}
