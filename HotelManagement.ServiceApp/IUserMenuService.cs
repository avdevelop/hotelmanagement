using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserMenuService" in both code and config file together.
    [ServiceContract]
    public interface IUserMenuService
    {
        [OperationContract]
        IEnumerable<UserMenuDTO> GetAll();

        [OperationContract]
        UserMenuDTO GetUserMenu(int id);

        [OperationContract]
        void Save(UserMenuDTO obj);

        [OperationContract]
        void Delete(UserMenuDTO obj);

        [OperationContract]
        IEnumerable<UserMenuDTO> GetByUser(int userId);
    }
}
