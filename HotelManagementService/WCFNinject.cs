using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using HotelManagement.Repository;
using HotelManagement.Models;

namespace HotelManagement.Service
{
    public class WCFNinject : NinjectModule
    {
        public override void Load()
        {
            //Injects the constructors of all DI-ed objects 
            //with a LinqToSQL implementation of IRepository
            Bind<IRepository<User>>().To<NHibernateRepository<User>>();
            Bind<IRepository<Booking>>().To<NHibernateRepository<Booking>>();
        }
    }
}
