using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.DTO
{
    public class BookingDTO
    {
        public virtual int Id { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }        
    }
}