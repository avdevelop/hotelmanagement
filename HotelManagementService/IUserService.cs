using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        IEnumerable<User> GetAll();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void Save(User obj);

        [OperationContract]
        void Delete(User obj);
    }
}
