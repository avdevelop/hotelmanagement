using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ServiceApp.DTO
{
    public class User
    {
        
        public virtual int Id { get; set; }

        
        public virtual string Email { get; set; }

        
        public virtual string Password { get; set; }

        
        public virtual UserType UserType { get; set; }
    }
}