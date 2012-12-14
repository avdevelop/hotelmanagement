using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HotelManagement.Repository
{
    public interface IRepository
    {
        IEnumerable Get();
        object Get(int id);
        void Save(object obj);
        void Delete(object obj);        
    }

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Save(T obj);
        void Delete(T obj);
    }

    public interface IRepositoryFactory<T> where T : class
    {
        IRepository<T> Resolve();
        void Release(IRepository<T> repository);
    }
}
