using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Setting
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual string Description { get; set; }
    }
}