/***************************************************************************\
Module Name:    Booking
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
    [KnownType(typeof(User))]
    public class Booking
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Phone { get; set; }

        [DataMember]
        public virtual DateTime Created { get; set; }

        [DataMember]
        public virtual DateTime Modified { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as Booking;
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
            return (Created.ToString() + "|" + Id).GetHashCode();
        }
    }
}