using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.DTO
{
    public class UserTypeDTO
    {        
        public virtual int Id { get; set; }        
        public virtual string Name { get; set; }
    }

    public enum UserTypeEnum
    {
        Admin = 1,
        Normal = 2
    }
}