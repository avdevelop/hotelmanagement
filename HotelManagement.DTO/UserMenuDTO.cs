using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.DTO
{
    public class UserMenuDTO
    {
        public virtual int Id { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual MenuDTO Menu { get; set; }
    }
}