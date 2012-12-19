/***************************************************************************\
Module Name:    BookingDetail
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HotelManagement.Models
{   
    public class BookingDetail
    {        
        public virtual int Id { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Room Room { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime Deleted { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as BookingDetail;
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
            return (Date.ToString() + "|" + Id + "|" + Room.Id).GetHashCode();
        }
    }
}