using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ServiceApp.DTO
{
    public class RoomDTO
    {        
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual HotelDTO HotelDTO { get; set; }
        public virtual RoomTypeDTO RoomTypeDTO { get; set; }
    }
}