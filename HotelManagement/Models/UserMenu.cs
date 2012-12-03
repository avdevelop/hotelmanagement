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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as UserMenu;
            if (t == null)
            {
                return false;            
            }

            if (User.Id == t.User.Id && Menu.Id == t.Menu.Id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (User.Email + "|" + Menu.Name).GetHashCode();
        }
    }
}