using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomService" in both code and config file together.
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        IEnumerable<RoomDTO> GetAll();

        [OperationContract]
        RoomDTO GetRoom(int id);

        [OperationContract]
        void Save(RoomDTO obj);

        [OperationContract]
        void Delete(RoomDTO obj);
    }
}
