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

namespace HotelManagement.ServiceApp
{
    [DataContract]
    public class BookingDetail
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual Booking Booking { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public virtual DateTime Date { get; set; }

        [DataMember]
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