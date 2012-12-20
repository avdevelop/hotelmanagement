using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelService" in both code and config file together.
    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        IEnumerable<HotelDTO> GetAll();

        [OperationContract]
        HotelDTO GetHotel(int id);

        [OperationContract]
        void Save(HotelDTO obj);

        [OperationContract]
        void Delete(HotelDTO obj);
    }
}
