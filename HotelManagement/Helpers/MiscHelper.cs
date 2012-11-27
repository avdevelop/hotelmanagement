using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Helpers
{
    public static class MiscHelper
    {
        public static SelectListItem EmptySelectListItem(this SelectList selectList)
        {
            SelectListItem item = new SelectListItem();
            item.Text = String.Empty;
            item.Value = "0";
            return item;
        }

        public static string SettingFromCache(this HtmlHelper helper, string settingName)
        {
            return AppCache.AppSettings.AllSettings.FirstOrDefault(s => s.Name == settingName).Value;                        
        }
    }
}