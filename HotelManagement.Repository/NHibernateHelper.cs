/***************************************************************************\
Module Name:    NHibernateHelper
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace HotelManagement.Repository
{
    public sealed class NHibernateHelper
    {        
        private static readonly ISessionFactory sessionFactory;
        private static ISession currentSession;

        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession();                
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();            
        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}