using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        IEnumerable<UserDTO> GetAll();

        [OperationContract]
        UserDTO GetUser(int id);

        [OperationContract]
        void Save(UserDTO obj);

        [OperationContract]
        void Delete(UserDTO obj);

        [OperationContract]
        UserDTO GetByEmail(string email);
    }
}
