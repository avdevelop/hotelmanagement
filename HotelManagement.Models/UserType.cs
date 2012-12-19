using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HotelManagement.Models
{    
    public class UserType
    {        
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public UserType()
        {

        }

        public UserType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as UserType;
            if (t == null)
            {
                return false;
            }

            if (Id == t.Id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Name + "|" + Id).GetHashCode();
        }
    }

    public enum UserTypeEnum
    {
        Admin = 1,
        Normal = 2
    }
}