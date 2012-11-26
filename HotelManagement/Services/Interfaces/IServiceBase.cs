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
        IEnumerable<T> Get<T>();
        T Get<T>(int id);
        void SaveOrUpdate<T>(T obj);
        void Delete<T>(T obj);
    }
}
