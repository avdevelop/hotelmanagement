[assembly: WebActivator.PreApplicationStartMethod(typeof(HotelManagement.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(HotelManagement.App_Start.NinjectWebCommon), "Stop")]

namespace HotelManagement.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;    
    using HotelManagement.Web.BookingDetailService;
    using HotelManagement.Web.BookingService;
    using HotelManagement.Web.HotelChainService;
    using HotelManagement.Web.HotelService;
    using HotelManagement.Web.MenuService;
    using HotelManagement.Web.RoomService;
    using HotelManagement.Web.RoomTypeService;
    using HotelManagement.Web.SettingService;
    using HotelManagement.Web.UserMenuService;
    using HotelManagement.Web.UserService;
    using HotelManagement.Web.UserTypeService;


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);                        
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IHotelService>().To<HotelServiceClient>();
            kernel.Bind<IHotelChainService>().To<HotelChainServiceClient>();
            kernel.Bind<IRoomService>().To<RoomServiceClient>();
            kernel.Bind<IRoomTypeService>().To<RoomTypeServiceClient>();
            kernel.Bind<ISettingService>().To<SettingServiceClient>();
            kernel.Bind<IUserService>().To<UserServiceClient>();
            kernel.Bind<IUserMenuService>().To<UserMenuServiceClient>();
            kernel.Bind<IMenuService>().To<MenuServiceClient>();
            kernel.Bind<IBookingService>().To<BookingServiceClient>();
            kernel.Bind<IBookingDetailService>().To<BookingDetailServiceClient>();
        }
    }
}
