using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Services.Interfaces;
using NHibernate;
using HotelManagement.Models.Mappings;
using HotelManagement.Models;
using System.Collections;

namespace HotelManagement.Services
{
    public class ServiceBase : IServiceBase
    {
        public IList GetAll<T>()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            session = NHibernateHelper.GetCurrentSession();
            tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            
            return (IList)criteria.List();
        }
    }
}