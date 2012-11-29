using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Tests.TestHelpers
{
    public static class TestDataHelper
    {
        public static IQueryable<UserMenu> UserMenus()
        {
            return new List<UserMenu>         
            {            
                new UserMenu 
                { 
                    Id = 1, 
                    Menu = new Menu 
                    { 
                        Id = 1, 
                        Name = "Hotels" 
                    }, 
                    User = new User 
                    { 
                        Id = 1, 
                        Email = "test@test.com" 
                    }
                },
                new UserMenu 
                { 
                    Id = 2, 
                    Menu = new Menu 
                    { 
                        Id = 2, 
                        Name = "HotelChains" 
                    }, 
                    User = new User 
                    { 
                        Id = 1, 
                        Email = "test@test.com" 
                    }
                }
            }.AsQueryable();
        }

        public static IQueryable<Hotel> Hotels()
        {
            return new List<Hotel>
            {
                Hotel1(),
                Hotel2(),
                Hotel3()
            }.AsQueryable();
        }

        public static IQueryable<HotelChain> HotelChains()
        {
            return new List<HotelChain>
            {
                HotelChain1(),
                HotelChain2()
            }.AsQueryable();
        }

        public static Hotel Hotel1()
        {
            return new Hotel
            {
                Id = 1,
                Name = "Aylesbury",
                HotelChain = HotelChain1(),
                InOperation = true
            };
        }

        public static Hotel Hotel2()
        {
            return new Hotel
            {
                Id = 2,
                Name = "Uxbridge",
                HotelChain = HotelChain2(),
                InOperation = true
            };
        }

        public static Hotel Hotel3()
        {
            return new Hotel
            {
                Id = 3,
                Name = "Central London",
                HotelChain = HotelChain1(),
                InOperation = true
            };
        }

        public static HotelChain HotelChain1()
        {
            return new HotelChain
            {
                Id = 1,
                Name = "CheapStayHotels"
            };
        }

        public static HotelChain HotelChain2()
        {
            return new HotelChain
            {
                Id = 2,
                Name = "FullFamilyHotels"
            };
        }
    }
}
