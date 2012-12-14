using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;

namespace HotelManagement.Repository
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

        public virtual void Save(T obj)
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

        IEnumerable IRepository.Get()
        {
            return Get();
        }

        object IRepository.Get(int id)
        {
            return Get(id);
        }

        void IRepository.Save(object obj)
        {
            Save((T)obj);
        }

        void IRepository.Delete(object obj)
        {
            Delete((T)obj);
        }        
    }
}