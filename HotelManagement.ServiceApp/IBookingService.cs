using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookingService" in both code and config file together.
    [ServiceContract]
    public interface IBookingService
    {
        [OperationContract]
        IEnumerable<BookingDTO> GetAll();

        [OperationContract]
        BookingDTO GetBooking(int id);

        [OperationContract]
        void Save(BookingDTO obj);

        [OperationContract]
        void Delete(BookingDTO obj);
    }    
}
