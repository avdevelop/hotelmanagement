/***************************************************************************\
Module Name:    AppCache
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Controllers;
using System.Collections;
using HotelManagement.Web.SettingService;

namespace HotelManagement.Helpers.CacheHelpers
{
    public static class AppCache
    {
        public static DateTime lastRefresh = new DateTime();        

        public static int AppCacheValidity
        {
            get
            {
                if (HttpContext.Current.Application["AppCache.AppSettings.AppCacheValidity"] == null)
                {
                    SettingServiceClient service = new SettingServiceClient();
                    //HttpContext.Current.Application["AppCache.AppSettings.AppCacheValidity"] = service.GetByName("AppCacheValidity").Value;
                }

                return int.Parse(HttpContext.Current.Application["AppCache.AppSettings.AppCacheValidity"].ToString());
            }
        }        

        public static IEnumerable<SettingDTO> AllSettings
        {
            get
            {
                if (DateTime.Now > lastRefresh.AddMinutes(AppCacheValidity))
                {
                    HttpContext.Current.Application["AppCache.AppSettings.AllSettings"] = null;
                    HttpContext.Current.Application["AppCache.AppSettings.AppCacheValidity"] = null;
                    lastRefresh = DateTime.Now;
                }

                if (HttpContext.Current.Application["AppCache.AppSettings.AllSettings"] == null)
                {
                    SettingServiceClient service = new SettingServiceClient();
                    HttpContext.Current.Application["AppCache.AppSettings.AllSettings"] = service.GetAll();
                }

                return (IEnumerable<SettingDTO>)HttpContext.Current.Application["AppCache.AppSettings.AllSettings"];
            }
        }
    }
}