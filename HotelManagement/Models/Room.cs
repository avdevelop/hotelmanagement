using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace HotelManagement.Models
{
    public class Room
    {
        [DisplayName("Room ID")]
        public virtual int Id { get; set; }

        [DisplayName("Room Name")]
        public virtual string Name { get; set; }
        
        [DisplayName("Hotel")]
        public virtual Hotel Hotel { get; set; }
    }
}