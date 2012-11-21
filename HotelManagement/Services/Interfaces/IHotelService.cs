using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Services.Interfaces
{
    public interface IHotelService : IServiceBase
    {
        T Get<T>(string name);
        T GetEnabled<T>();
        T GetDisabled<T>();
    }
}
