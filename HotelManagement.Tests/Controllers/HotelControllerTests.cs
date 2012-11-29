using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelManagement.Controllers;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;
using Rhino.Mocks;
using HotelManagement.Tests.TestHelpers;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HotelManagement.Tests.Controllers
{
    [TestClass]
    public class HotelControllerTests
    {
        HotelController hotelController;
        IRepository<Hotel> hotelRepository;
        IRepository<HotelChain> hotelChainRepository;

        public HotelControllerTests()
        {
            hotelRepository = MockRepository.GenerateStub<IRepository<Hotel>>();            
            hotelChainRepository = MockRepository.GenerateStub<IRepository<HotelChain>>();
            hotelController = new HotelController(hotelRepository, hotelChainRepository);            
        }

        [TestMethod]
        public void IndexShouldRenderViewIndex()
        {
            var hotels = TestDataHelper.Hotels();
            var hotelChains = TestDataHelper.HotelChains();

            hotelRepository.Expect(h => h.Get()).Return(hotels);
            hotelController.AddMockHttpContext();
                        
            hotelController.Index()
                .ReturnsViewResult()            
                .AssertAreSame("Index", v => v.ViewName)
                .WithModel<IEnumerable<Hotel>>();
        }

        [TestMethod]
        public void EditShouldRenderViewEdit()
        {
            var hotel = TestDataHelper.Hotel1();
            var hotelChains = TestDataHelper.HotelChains();

            hotelRepository.Expect(h => h.Get(hotel.Id)).Return(hotel);
            hotelController.AddMockHttpContext();


            hotelController.Edit(1)
                .ReturnsViewResult()
                .AssertAreSame("Edit", v => v.ViewName)
                .WithModel<Hotel>()
                .Id.Equals(hotel.Id);
        }
        
    }
}
