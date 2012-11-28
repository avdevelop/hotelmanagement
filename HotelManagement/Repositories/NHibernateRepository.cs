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
    public class NHibernateRepository<T> : IRepository<T>, IRepository where T : class
    {
        public virtual IEnumerable<T> Get()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ICriteria criteria = session.CreateCriteria(typeof(T).Name);            
            return criteria.List().OfType<T>();
        }

        public virtual T Get(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();            
            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("Id", id));
            return (T)criteria.UniqueResult();
        }

        public virtual void SaveOrUpdate(T obj)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            session.SaveOrUpdate(obj);
        }

        public virtual void Delete(T obj)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            session.Delete(obj);
            session.Flush();
            session.Close();
        }

        public virtual T GetByName(string name)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria(typeof(T).Name);
            criteria.Add(Expression.Eq("Name", name));

            return (T)criteria.UniqueResult();
        }

        IEnumerable IRepository.Get()
        {
            return Get();
        }

        object IRepository.Get(int id)
        {
            return Get(id);
        }

        void IRepository.SaveOrUpdate(object obj)
        {
            SaveOrUpdate((T)obj);
        }

        void IRepository.Delete(object obj)
        {
            Delete((T)obj);
        }

        object IRepository.GetByName(string name)
        {
            return GetByName(name);
        }
    }
}