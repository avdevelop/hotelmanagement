/***************************************************************************\
Module Name:    UserController
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;
using HotelManagement.Helpers.CacheHelpers;

namespace HotelManagement.Controllers
{
    public class UserController : BaseController
    {
        IRepository<User> userRepository;

        public UserController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        //
        // GET: /User/
        // GET: /User/Index
        public ActionResult Index()
        {
            ReturnUrlSet();
            return View("Index");
        }

        //
        // GET: /User/Edit        
        public ActionResult Edit()
        {
            ReturnUrlSet();
            if (SessionCache.UserId.HasValue)
            {
                return View("Edit", userRepository.Get(SessionCache.UserId.Value));
            }
            else
            {
                return View("Edit", userRepository.Get(SessionCache.UserId.Value));
            }
            
        }

    }
}
