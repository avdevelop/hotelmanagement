using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.Services.Interfaces
{
    public interface IHotelService : IServiceBase
    {
        T Get<T>(string name);
        IEnumerable<Hotel>  GetEnabled();
        IEnumerable<Hotel> GetDisabled();
        string ValidateSave(Hotel hotel);
        string ValidateDelete(Hotel hotel);
    }
}
