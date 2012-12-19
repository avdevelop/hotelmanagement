using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.ServiceApp.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomTypeService" in both code and config file together.
    [ServiceContract]
    public interface IRoomTypeService
    {
        [OperationContract]
        IEnumerable<RoomTypeDTO> GetAll();

        [OperationContract]
        RoomTypeDTO GetRoom(int id);

        [OperationContract]
        void Save(RoomTypeDTO obj);

        [OperationContract]
        void Delete(RoomTypeDTO obj);
    }
}
