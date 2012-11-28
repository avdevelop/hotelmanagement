using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelManagement.Controllers;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;
using Rhino.Mocks;

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

        
    }
}
