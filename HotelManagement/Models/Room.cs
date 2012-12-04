/***************************************************************************\
Module Name:    Room
Author:         Viral Christian
Description:    

\***************************************************************************/

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

        [DisplayName("RoomType")]
        public virtual RoomType RoomType { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as Room;
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
}