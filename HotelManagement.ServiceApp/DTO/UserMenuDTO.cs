using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ServiceApp.DTO
{
    public class UserMenuDTO
    {
        public virtual int Id { get; set; }
        public virtual UserDTO UserDTO { get; set; }
        public virtual MenuDTO MenuDTO { get; set; }
    }
}