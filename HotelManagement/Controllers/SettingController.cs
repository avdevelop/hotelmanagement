using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class SettingController : Controller
    {
        private ISettingService settingService;

        public SettingController(ISettingService service)
        {
            this.settingService = service;
        }

        //
        // GET: /Setting/

        public ActionResult Index()
        {
            return View();
        }

        public string GetSetting(string name)
        {
            return settingService.Get<Setting>(name).Value;
        }
    }
}
