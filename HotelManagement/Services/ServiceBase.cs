using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services.Interfaces;
using NHibernate;
using HotelManagement.Models.Mappings;
using HotelManagement.Models;
using System.Collections;
using NHibernate.Criterion;

namespace HotelManagement.Services
{
    public class ServiceBase : IServiceBase
    {
        public IEnumerable<T> Get<T>()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(T).Name);            
            return criteria.List().OfType<T>();
        }
        
        public T Get<T>(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();            
            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("Id", id));
            return (T)criteria.UniqueResult();
        }

        public void SaveOrUpdate<T>(T obj)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            session.SaveOrUpdate(obj);
        }
    }
}