using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class UserMenu
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Menu Menu { get; set; }
    }
}