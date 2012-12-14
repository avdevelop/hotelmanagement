using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ServiceApp.DTO
{
    public class Booking
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }        
    }
}