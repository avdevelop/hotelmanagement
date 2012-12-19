using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ServiceApp.DTO
{
    public class BookingDetailDTO
    {
        public virtual int Id { get; set; }
        public virtual BookingDTO BookingDTO { get; set; }
        public virtual RoomDTO RoomDTO { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime Deleted { get; set; }
    }
}