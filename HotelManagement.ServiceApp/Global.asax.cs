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

namespace HotelManagement.ServiceApp
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            Mapper.CreateMap<Booking, HotelManagement.ServiceApp.DTO.Booking>();
            Mapper.CreateMap<User, HotelManagement.ServiceApp.DTO.User>();
            Mapper.CreateMap<UserType, HotelManagement.ServiceApp.DTO.UserType>();

            //Mapper.CreateMap<IEnumerable<Booking>, IEnumerable<BookingDTO>>();
            //Mapper.CreateMap<IEnumerable<User>, IEnumerable<UserDTO>>();
            //Mapper.CreateMap<IEnumerable<UserType>, IEnumerable<UserTypeDTO>>();
            Mapper.AssertConfigurationIsValid();



            StandardKernel kernel = new StandardKernel(new WCFNinject());
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            return kernel;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Mapper.AssertConfigurationIsValid();
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