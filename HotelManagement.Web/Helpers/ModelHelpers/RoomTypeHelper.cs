/***************************************************************************\
Module Name:    RoomTypeHelper
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.DTO;

namespace HotelManagement.Helpers.ModelHelpers
{
    public static class RoomTypeHelper
    {
        public static RoomTypeDTO Instance(this RoomTypeDTO roomType, string format)
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