using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Services.Interfaces
{
    public interface IRoomService : IServiceBase
    {
        string ValidateSave(Room room);
        string ValidateDelete(Room room);
    }
}
