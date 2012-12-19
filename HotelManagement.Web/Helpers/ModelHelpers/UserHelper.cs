/***************************************************************************\
Module Name:    UserHelper
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Web.UserService;

namespace HotelManagement.Helpers.ModelHelpers
{
    public static class UserHelper
    {
        public static bool Login(UserDTO user, string pass)
        {
            if (user.Password.Equals(pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}