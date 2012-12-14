/***************************************************************************\
Module Name:    Hotel
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
    public class Hotel
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual HotelChain HotelChain { get; set; }

        [DataMember]
        public virtual string Address1 { get; set; }

        [DataMember]
        public virtual string Address2 { get; set; }

        [DataMember]
        public virtual string Address3 { get; set; }

        [DataMember]
        public virtual string Address4 { get; set; }

        [DataMember]
        public virtual string Address5 { get; set; }

        [DataMember]
        public virtual bool InOperation { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as Hotel;
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