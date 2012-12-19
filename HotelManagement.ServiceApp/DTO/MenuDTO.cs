using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ServiceApp.DTO
{
    public class MenuDTO
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Order { get; set; }
        public virtual string Action { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Tooltip { get; set; }
    }
}