using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.ServiceApp.DTO;
using HotelManagement.Models;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserTypeService" in both code and config file together.
    [ServiceContract]
    public interface IUserTypeService
    {
        [OperationContract]
        IEnumerable<UserTypeDTO> GetAll();

        [OperationContract]
        UserTypeDTO GetUserType(int id);

        [OperationContract]
        void Save(UserTypeDTO obj);

        [OperationContract]
        void Delete(UserTypeDTO obj);

        [OperationContract]
        UserTypeEnum UserType(int id);
    }
}
