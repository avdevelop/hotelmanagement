using System.Collections.Generic;
using HotelManagement.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HotelManagement.Services.Interfaces;
using System.Web.Mvc;
using NUnit.Framework;
using Rhino.Mocks;
using HotelManagement.Models;
using HotelManagement.Tests.TestHelpers;

namespace HotelManagement.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        HomeController homeController;
        IRepository<UserMenu> userMenuRepository;

        public HomeControllerTests()
        {
            userMenuRepository = MockRepository.GenerateStub<IRepository<UserMenu>>();
            homeController = new HomeController(userMenuRepository);
        }
        
        [TestMethod]
        public void IndexShouldRenderViewIndex()
        {
            var userMenu = TestDataHelper.TestUserMenus();            

            userMenuRepository.Expect(um => um.Get()).Return(userMenu);

            homeController.Index()
                .ReturnsViewResult()            
                .AssertAreSame("Index", v => v.ViewName)
                .WithModel<UserMenu>();
        }
    }    
}
