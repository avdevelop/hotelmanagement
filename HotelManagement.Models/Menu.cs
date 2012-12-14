/***************************************************************************\
Module Name:    Menu
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
    public class Menu
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual int Order { get; set; }

        [DataMember]
        public virtual string Action { get; set; }

        [DataMember]
        public virtual string Controller { get; set; }

        [DataMember]
        public virtual string Tooltip { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var t = obj as Menu;
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