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
            hotelRepository = MockRepository.GenerateMock<IRepository<Hotel>>();
            hotelChainRepository = MockRepository.GenerateMock<IRepository<HotelChain>>();
            hotelController = new HotelController(hotelRepository, hotelChainRepository);

            hotelRepository.Expect(h => h.Get()).Return(TestDataHelper.Hotels());
            hotelRepository.Expect(h => h.Get(1)).Return(hotelRepository.Get().First(h => h.Id == 1));
            hotelRepository.Expect(h => h.Get(2)).Return(hotelRepository.Get().First(h => h.Id == 2) );
            hotelRepository.Expect(h => h.Get(10)).Return(hotelRepository.Get().FirstOrDefault(h => h.Id == 10));

            hotelChainRepository.Expect(h => h.Get()).Return(TestDataHelper.HotelChains());
            hotelChainRepository.Expect(h => h.Get(1)).Return(hotelChainRepository.Get().First(hc => hc.Id == 1));
            hotelChainRepository.Expect(h => h.Get(2)).Return(hotelChainRepository.Get().First(hc => hc.Id == 2));

            hotelController.AddMockHttpContext();
        }

        [TestMethod]
        public void IndexShouldRenderViewIndex()
        {
            hotelController.Index()
                .ReturnsViewResult()            
                .AssertAreSame("Index", v => v.ViewName)
                .WithModel<IEnumerable<Hotel>>();
        }

        [TestMethod]
        public void EditShouldRenderViewEdit()
        {
            hotelController.Edit(1)
                .ReturnsViewResult()
                .AssertAreSame("Edit", v => v.ViewName)
                .WithModel<Hotel>()
                .Id.Equals(1);
        }

        [TestMethod]
        public void AddShouldRenderViewAdd()
        {
            hotelController.Add(hotelRepository.Get(1))
                .ReturnsViewResult()
                .AssertAreSame("Add", v => v.ViewName)
                .WithModel<Hotel>()
                .Id.Equals(1);
        }

        [TestMethod]
        public void CreateShouldRenderViewSuccess()
        {
            var hotel = new Hotel { Id = 10, Name = "Testing", HotelChain = hotelChainRepository.Get(1) };
            
            hotelController.Create(hotel)
                .ReturnsRedirectToRouteResult();

            hotelRepository.Delete

            hotelRepository.Get(10).IsNotNull();
        }
    }
}
