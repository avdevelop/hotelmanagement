using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Services.Interfaces
{
    public interface IRoomTypeService : IServiceBase
    {
        IEnumerable<RoomType> Get<T>(string nameFormat);
    }
}
