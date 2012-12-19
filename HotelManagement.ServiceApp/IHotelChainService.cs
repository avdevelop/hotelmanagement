using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.ServiceApp.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelChainService" in both code and config file together.
    [ServiceContract]
    public interface IHotelChainService
    {
        [OperationContract]
        IEnumerable<HotelChainDTO> GetAll();

        [OperationContract]
        HotelChainDTO GetHotelChain(int id);

        [OperationContract]
        void Save(HotelChainDTO obj);

        [OperationContract]
        void Delete(HotelChainDTO obj);
    }
}
