using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;
using System.Collections;

namespace HotelManagement.Services.Interfaces
{
    //public IEnumerable<RoomType> Get<T>(string nameFormat)
    //    {
    //        ISession session = NHibernateHelper.GetCurrentSession();
    //        ICriteria criteria = session.CreateCriteria(typeof(T).Name);

    //        List<RoomType> roomTypes = new List<RoomType>();

    //        foreach (RoomType roomType in criteria.List().OfType<RoomType>())
    //        { 
    //            roomTypes.Add(roomType.Instance(nameFormat));
    //        }
            
    //        return roomTypes;
    //    }

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
