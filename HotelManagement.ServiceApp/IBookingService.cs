using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookingService" in both code and config file together.
    [ServiceContract]
    public interface IBookingService
    {
        [OperationContract]
        List<A> GetAll1();

        [OperationContract]
        IEnumerable<HotelManagement.ServiceApp.DTO.Booking> GetAll();

        [OperationContract]
        Booking GetBooking(int id);

        [OperationContract]
        void Save(Booking obj);

        [OperationContract]
        void Delete(Booking obj);
    }    
}
