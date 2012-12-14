/***************************************************************************\
Module Name:    User
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
    public class User
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        [DataMember]
        public virtual UserType UserType { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }

        //    var t = obj as User;
        //    if (t == null)
        //    {
        //        return false;
        //    }

        //    if (Id == t.Id)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return (Email + "|" + Id).GetHashCode();
        //}
    }
}