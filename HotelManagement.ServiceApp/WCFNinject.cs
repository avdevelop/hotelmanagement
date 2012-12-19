using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using HotelManagement.Repository;
using HotelManagement.Models;

namespace HotelManagement.ServiceApp
{
    public class WCFNinject : NinjectModule
    {
        public override void Load()
        {
            //Injects the constructors of all DI-ed objects 
            //with a LinqToSQL implementation of IRepository
            Bind<IRepository<User>>().To<NHibernateRepository<User>>();
            Bind<IRepository<UserType>>().To<NHibernateRepository<UserType>>();
            Bind<IRepository<Booking>>().To<NHibernateRepository<Booking>>();
            Bind<IRepository<BookingDetail>>().To<NHibernateRepository<BookingDetail>>();
            Bind<IRepository<Hotel>>().To<NHibernateRepository<Hotel>>();
            Bind<IRepository<HotelChain>>().To<NHibernateRepository<HotelChain>>();
            Bind<IRepository<Room>>().To<NHibernateRepository<Room>>();
            Bind<IRepository<RoomType>>().To<NHibernateRepository<RoomType>>();
            Bind<IRepository<Setting>>().To<NHibernateRepository<Setting>>();
            Bind<IRepository<Menu>>().To<NHibernateRepository<Menu>>();
            Bind<IRepository<UserMenu>>().To<NHibernateRepository<UserMenu>>();
        }
    }
}
