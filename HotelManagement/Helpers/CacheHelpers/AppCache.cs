/***************************************************************************\
Module Name:    AppCache
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services;
using HotelManagement.Controllers;
using HotelManagement.Models;
using System.Collections;

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
                    NHibernateRepository<Setting> service = new NHibernateRepository<Setting>();
                    HttpContext.Current.Application["AppCache.AppSettings.AppCacheValidity"] = service.GetByName("AppCacheValidity").Value;
                }

                return int.Parse(HttpContext.Current.Application["AppCache.AppSettings.AppCacheValidity"].ToString());
            }
        }        

        public static IEnumerable<Setting> AllSettings
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
                    NHibernateRepository<Setting> service = new NHibernateRepository<Setting>();
                    HttpContext.Current.Application["AppCache.AppSettings.AllSettings"] = service.Get();
                }

                return (IEnumerable<Setting>)HttpContext.Current.Application["AppCache.AppSettings.AllSettings"];
            }
        }
    }
}