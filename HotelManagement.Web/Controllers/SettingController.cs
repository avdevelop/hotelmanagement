/***************************************************************************\
Module Name:    SettingController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Helpers.CacheHelpers;
using HotelManagement.Helpers;
using HotelManagement.Web.SettingService;
using HotelManagement.Web.UserTypeService;

namespace HotelManagement.Controllers
{
    public class SettingController : BaseController
    {
        private ISettingService settingService;

        public SettingController(ISettingService settingRepository)
        {
            this.settingService = settingRepository;
        }

        //
        // GET: /Setting/
        // GET: /Setting/Index
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Index()
        {
            if (SessionCache.UserId != null)
            {

                var hotels = settingService.GetAll();

                if (HttpContext.Request.UrlReferrer != null)
                {
                    ViewData["DeleteReturn"] = HttpContext.Request.UrlReferrer.OriginalString;
                }
                else
                {
                    ViewData["DeleteReturn"] = String.Empty;
                }

                return View("Index", hotels);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //
        // GET: /Setting/Edit/id
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Edit(int id)
        {
            if (SessionCache.UserId != null)
            {
                var setting = settingService.GetSetting(id);
                return View("Edit", setting);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //
        // GET: /Setting/Add
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Add(SettingDTO setting)
        {
            if (SessionCache.UserId != null)
            {
                ViewBag.ValidationError = TempData["ValidationError"];
                return View("Add", setting);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //
        // POST: /Setting/Create
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Create(SettingDTO setting)
        {
            if (SessionCache.UserId != null)
            {
                string error = "";

                if (error.Length == 0)
                {
                    settingService.Save(setting);
                    return RedirectToAction("Success", "Setting", new { message = "Successfully saved the Setting." });
                }
                else
                {
                    TempData["ValidationError"] = error;
                    return RedirectToAction("Add", "Setting", setting);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //
        // GET: /Setting/Sucess        
        public ActionResult Success(string message)
        {
            if (SessionCache.UserId != null)
            {
                return View("Success", (object)message);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //
        // POST: /Setting/Delete/setting
        [Authenticate(UserTypeEnum.Admin)]
        public ActionResult Delete(SettingDTO setting, int? id)
        {
            if (SessionCache.UserId != null)
            {
                string error = "";

                if (error.Length == 0)
                {
                    setting = settingService.GetSetting(setting.Id);
                    settingService.Delete(setting);
                    return View("Success", (object)"Setting deleted successfully.");
                }
                else
                {
                    return Redirect((string)ViewData["DeleteReturn"]);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }       
    }
}
