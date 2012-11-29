using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;
using System.Collections;

namespace HotelManagement.Services.Interfaces
{
    public interface IRepository
    {
        IEnumerable Get();
        object Get(int id);
        void SaveOrUpdate(object obj);
        void Delete(object obj);
        object GetByName(string name);
    }

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void SaveOrUpdate(T obj);
        void Delete(T obj);
        T GetByName(string name);
    }

    public interface IRepositoryFactory<T> where T : class
    {
        IRepository<T> Resolve();
        void Release(IRepository<T> repository);
    }
}
