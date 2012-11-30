/***************************************************************************\
Module Name:    SessionCache
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Models;

namespace HotelManagement.Helpers.CacheHelpers
{
    public static class SessionCache
    {
        public static void CreateSession(int userId,
            string email)
        {
            UserId = userId;
            UserEmail = UserEmail;
            LoginFailCount = 0;
        }

        public static int? UserId
        {
            get
            {
                return (int?)HttpContext.Current.Session["SessionCache.UserId"];
            }

            set
            {
                HttpContext.Current.Session["SessionCache.UserId"] = value;
            }
        }

        public static string UserEmail
        {
            get
            {
                return (string)HttpContext.Current.Session["SessionCache.UserEmail"];
            }

            set
            {
                HttpContext.Current.Session["SessionCache.UserEmail"] = value;
            }
        }

        public static int LoginFailCount
        {
            get
            {
                return (int)HttpContext.Current.Session["SessionCache.LoginFailCount"];
            }

            set
            {
                HttpContext.Current.Session["SessionCache.LoginFailCount"] = value;
            }
        }
    }
}