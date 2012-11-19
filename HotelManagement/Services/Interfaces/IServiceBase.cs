using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;
using System.Collections;

namespace HotelManagement.Services.Interfaces
{
    public interface IServiceBase
    {
        IList GetAll<T>();
    }
}
