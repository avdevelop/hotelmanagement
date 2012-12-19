using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Ninject.Extensions.Wcf;
using Ninject;
using Ninject.Web.Common;
using AutoMapper;
using HotelManagement.Models;
using HotelManagement.ServiceApp.DTO;

namespace HotelManagement.ServiceApp
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            //Mapper.CreateMap<HotelChain, HotelChainDTO>();
            //Mapper.CreateMap<HotelChainDTO, HotelChain>();

            //Mapper.CreateMap<Hotel, HotelDTO>();
            //Mapper.CreateMap<HotelDTO, Hotel>();
            
            //Mapper.CreateMap<Booking, BookingDTO>();
            //Mapper.CreateMap<BookingDTO, Booking>();

            //Mapper.CreateMap<User, UserDTO>();
            //Mapper.CreateMap<UserDTO, User>();

            //Mapper.CreateMap<UserType, UserTypeDTO>();
            //Mapper.CreateMap<UserTypeDTO, UserType>();

            //Mapper.CreateMap<Setting, SettingDTO>();
            //Mapper.CreateMap<SettingDTO, Setting>();

            //Mapper.CreateMap<Menu, MenuDTO>();
            //Mapper.CreateMap<MenuDTO, Menu>();

            //Mapper.CreateMap<UserMenu, UserMenuDTO>();
            //Mapper.CreateMap<UserMenuDTO, UserMenu>();

            Mapper.AssertConfigurationIsValid();



            StandardKernel kernel = new StandardKernel(new WCFNinject());
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            return kernel;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}