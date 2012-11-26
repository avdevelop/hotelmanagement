using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class RoomService : ServiceBase, IRoomService
    {
        public string ValidateSave(Room room)
        {
            string error = String.Empty;

            if (String.IsNullOrEmpty(room.Name))
            {
                error = "Invalid Room Name entered.";
                return error;
            }

            if (room.Hotel == null || room.Hotel.Id <= 0)
            {
                error = "Please select a valid Hotel for this Room.";
                return error;
            }

            if (room.RoomType == null || room.RoomType.Id <= 0)
            {
                error = "Please select a valid Room Type for this Room.";
                return error;
            }

            return error;
        }
    }
}