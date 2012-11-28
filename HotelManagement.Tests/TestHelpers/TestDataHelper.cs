using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Tests.TestHelpers
{
    public static class TestDataHelper
    {
        public static IQueryable<UserMenu> TestUserMenus()
        {
            return new List<UserMenu>         
            {            
                new UserMenu 
                { 
                    Id = 1, Menu = new Menu 
                    { 
                        Id = 1, Name = "Hotels" 
                    }, User = new User 
                    { 
                        Id = 1, Email = "test@test.com" 
                    }
                }
            }.AsQueryable();
        }
    }
}
