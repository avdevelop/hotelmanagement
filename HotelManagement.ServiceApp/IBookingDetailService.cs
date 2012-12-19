using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelManagement.ServiceApp.DTO;

namespace HotelManagement.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookingDetailService" in both code and config file together.
    [ServiceContract]
    public interface IBookingDetailService
    {
        [OperationContract]
        IEnumerable<BookingDetailDTO> GetAll();

        [OperationContract]
        BookingDetailDTO GetBookingDetail(int id);

        [OperationContract]
        void Save(BookingDetailDTO obj);

        [OperationContract]
        void Delete(BookingDetailDTO obj);
    }
}
