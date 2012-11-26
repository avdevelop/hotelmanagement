using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace HotelManagement.Models
{
    public class RoomType
    {
        [DisplayName("Room Type ID")]
        public virtual int Id { get; set; }

        [DisplayName("Room Type")]
        public virtual string Name { get; set; }

        [DisplayName("Room")]
        public virtual Room Room { get; set; }
    }
}