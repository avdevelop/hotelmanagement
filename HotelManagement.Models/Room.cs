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
using System.Runtime.Serialization;

namespace HotelManagement.ServiceApp
{
    [DataContract]
    public class Room
    {
        [DataMember]
        [DisplayName("Room ID")]
        public virtual int Id { get; set; }

        [DataMember]
        [DisplayName("Room Name")]
        public virtual string Name { get; set; }

        [DataMember]
        [DisplayName("Hotel")]
        public virtual Hotel Hotel { get; set; }

        [DataMember]
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