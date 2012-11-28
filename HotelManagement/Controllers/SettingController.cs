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
        private IRepository<Setting> settingRepository;

        public SettingController(IRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        //
        // GET: /Setting/

        public ActionResult Index()
        {
            return View();
        }

        public string GetSetting(string name)
        {
            return settingRepository.GetByName(name).Value;
        }
    }
}
