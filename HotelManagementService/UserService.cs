using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Models;
using HotelManagement.Repository;

namespace HotelManagement.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;        

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.Get();
        }

        public User GetUser(int id)
        {
            return userRepository.Get(id);
        }

        public void Save(User obj)
        {
            userRepository.Save(obj);
        }

        public void Delete(User obj)
        {
            userRepository.Delete(obj);
        }
    }
}
