using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models.Mappings;
using NHibernate;
using HotelManagement.Models;
using System.Collections;
using NHibernate.Criterion;

namespace HotelManagement.Services
{
    public class HotelService : ServiceBase, IHotelService
    {
        public T Get<T>(string name)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("Name", name));

            return (T)criteria.UniqueResult();
        }

        public T GetEnabled<T>()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("InOperation", true));

            return (T)criteria.UniqueResult();
        }

        public T GetDisabled<T>()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("InOperation", false));

            return (T)criteria.UniqueResult();
        }
    }
}