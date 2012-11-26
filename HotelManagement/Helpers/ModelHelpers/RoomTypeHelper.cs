using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Models;

namespace HotelManagement.Helpers.ModelHelpers
{
    public static class RoomTypeHelper
    {
        public static RoomType Instance(this RoomType roomType, string format)
        {
            switch (format)
            { 
                case "Name (MaxOccupants)":
                    roomType.Name = roomType.Name += " (" + roomType.MaxOccupants + ")";
                    break;                
            }
            
            return roomType;
        }
    }
}