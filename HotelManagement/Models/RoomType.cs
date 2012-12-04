/***************************************************************************\
Module Name:    RoomType
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
    public class RoomType
    {
        [DisplayName("Room Type ID")]
        public virtual int Id { get; set; }

        [DisplayName("Room Type")]
        public virtual string Name { get; set; }

        [DisplayName("Maximum Occupancy")]
        public virtual int MaxOccupants { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as RoomType;
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