using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.DTO
{
    public class BookingDetailDTO
    {
        public virtual int Id { get; set; }
        public virtual BookingDTO Booking { get; set; }
        public virtual RoomDTO Room { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime Deleted { get; set; }
    }
}