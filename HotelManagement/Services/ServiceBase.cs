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
        public IList Get<T>()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();
            
            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            
            return (IList)criteria.List();
        }


        public T Get<T>(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("Id", id));

            return (T)criteria.UniqueResult();
        }
    }
}