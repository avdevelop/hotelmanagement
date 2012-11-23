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

        public IEnumerable<Hotel> GetEnabled()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria("Hotel");
            criteria.Add(Expression.Eq("InOperation", true));

            return criteria.List<Hotel>();
        }

        public IEnumerable<Hotel> GetDisabled()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tran = session.BeginTransaction();

            ICriteria criteria = session.CreateCriteria("Hotel");
            criteria.Add(Expression.Eq("InOperation", false));

            return criteria.List<Hotel>();
        }

        public string Validate(Hotel hotel)
        {
            string error = String.Empty;

            if (String.IsNullOrEmpty(hotel.Name))
            {
                error = "Invalid Hotel Name entered.";
                return error;
            }

            if (hotel.HotelChain == null || hotel.HotelChain.Id <= 0)
            {
                error = "Please select a valid Hotel Chain for this Hotel.";
                return error;
            }
            
            return error;
        }
    }
}