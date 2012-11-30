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
using Rhino.Mocks.Impl;

namespace HotelManagement.Tests.Controllers
{
    [TestClass]
    public class HotelControllerTests
    {
        HotelController hotelController;
        IRepository<Hotel> hotelRepository;
        IRepository<HotelChain> hotelChainRepository;

        MockRepository mock = new MockRepository();

        public delegate void DelegateHotelAdd(Hotel newHotel);
        public delegate void DelegateHotelEdit(Hotel newHotel);

        List<Hotel> hotels = new List<Hotel>();
        List<HotelChain> hotelChains = new List<HotelChain>();

        public static string newValue = String.Empty;

        public HotelControllerTests()
        {
            RhinoMocks.Logger = new TextWriterExpectationLogger(Console.Out);

            hotelRepository = mock.StrictMock<IRepository<Hotel>>() ;
            hotelChainRepository = mock.StrictMock<IRepository<HotelChain>>();
            hotelController = new HotelController(hotelRepository, hotelChainRepository);

            hotels.Add(TestDataHelper.Hotel1());
            hotels.Add(TestDataHelper.Hotel2());
            hotels.Add(TestDataHelper.Hotel3());

            hotelChains.Add(TestDataHelper.HotelChain1());
            hotelChains.Add(TestDataHelper.HotelChain2());
            
            hotelRepository.Expect(h => h.Get()).Return(hotels);
            hotelRepository.Expect(h => h.Get(1)).Return(hotels.FirstOrDefault(h => h.Id == 1));
            hotelRepository.Expect(h => h.Get(2)).Return(hotels.FirstOrDefault(h => h.Id == 2));
            hotelRepository.Expect(h => h.Get(3)).Return(hotels.FirstOrDefault(h => h.Id == 3));
            hotelRepository.Expect(h => h.Get(10)).Return(hotels.FirstOrDefault(h => h.Id == 10));
            
            hotelChainRepository.Expect(h => h.Get()).Return(hotelChains);
            hotelChainRepository.Expect(h => h.Get(1)).Return(hotelChains.FirstOrDefault(h => h.Id == 1));
            hotelChainRepository.Expect(h => h.Get(2)).Return(hotelChains.FirstOrDefault(h => h.Id == 2));
            
            hotelController.AddMockHttpContext();
        }

        [TestMethod]
        public void IndexShouldRenderViewIndex()
        {
            mock.ReplayAll();

            hotelController.Index()
                .ReturnsViewResult()            
                .AssertAreSame("Index", v => v.ViewName)
                .WithModel<IEnumerable<Hotel>>();
        }

        [TestMethod]
        public void EditShouldRenderViewEdit()
        {
            mock.ReplayAll();

            hotelController.Edit(1)
                .ReturnsViewResult()
                .AssertAreSame("Edit", v => v.ViewName)
                .WithModel<Hotel>()
                .Id.Equals(1);
        }

        [TestMethod]
        public void AddShouldRenderViewAdd()
        {
            mock.ReplayAll();

            hotelController.Add(hotelRepository.Get(1))
                .ReturnsViewResult()
                .AssertAreSame("Add", v => v.ViewName)
                .WithModel<Hotel>()
                .Id.Equals(1);
        }

        [TestMethod]
        public void CreateShouldRenderViewSuccess()
        {
            mock.ReplayAll();
            
            var hotel = new Hotel { Id = 0, Name = "Testing", HotelChain = hotelChainRepository.Get(1) };
            
            hotelRepository.Expect(h => h.SaveOrUpdate(hotel)).Do(new DelegateHotelAdd(HotelAdd));

            hotelController.Create(hotel)
                .ReturnsRedirectToRouteResult();
            
            hotels.FirstOrDefault(h => h.Id == hotel.Id).IsNotNull();            
        }

        public void HotelAdd(Hotel newHotel)
        {
            hotels.Add(newHotel);
        }

        [TestMethod]
        public void EditHotelShouldUpdateHotelInList()
        {
            mock.ReplayAll();

            var hotel = hotels.FirstOrDefault(h => h.Id == 3);

            hotelRepository.Expect(h => h.SaveOrUpdate(hotel)).Do(new DelegateHotelAdd(HotelEdit));

            newValue = "New";

            hotel.Name = newValue;
            RedirectToRouteResult result = hotelController.Create(hotel).ReturnsRedirectToRouteResult();

            Assert.AreEqual(result.RouteValues["action"], "Success");
            Assert.AreEqual(result.RouteValues["controller"], "Hotel");

            hotels.FirstOrDefault(h => String.Compare(h.Name, newValue) == 0).IsNotNull();
        }        

        public void HotelEdit(Hotel newHotel)
        {
            hotels.FirstOrDefault(h => h.Id == newHotel.Id).Name = newValue;
        }
    }
}
