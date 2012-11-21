using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services.Interfaces;
using HotelManagement.Models.Mappings;
using NHibernate;
using NHibernate.Criterion;

namespace HotelManagement.Services
{
    public class SettingService : ServiceBase, ISettingService
    {   
        public T Get<T>(string name)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("Name", name));

            return (T)criteria.UniqueResult();
        }
    }
}