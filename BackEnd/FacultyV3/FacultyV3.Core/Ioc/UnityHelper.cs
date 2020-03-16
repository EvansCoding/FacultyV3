using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Ioc
{
    using System.Web.Mvc;
    using Data.Context;
    using Interfaces.IServices;
    using Services;
    using Interfaces;
    using Unity;
    using Unity.Lifetime;

    /// <summary>
    ///     Bind the given interface in request scope
    /// </summary>
    public static class IocExtensions
    {
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }
    }

    /// <summary>
    ///     The injection for Unity
    /// </summary>
    public static class UnityHelper
    {
        public static IUnityContainer Container;

        public static void InitialiseUnityContainer()
        {
            Container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));

            Container.BindInRequestScope<IConfigService, ConfigService>();
            Container.BindInRequestScope<ICacheService, CacheService>();
        }

        /// <summary>
        ///     Inject
        /// </summary>
        /// <returns></returns>
        public static void BuildUnityContainer()
        {
            Container.BindInRequestScope<IDataContext, DataContext>();
            Container.BindInRequestScope<IBannerService, BannerService>();
            Container.BindInRequestScope<IDescriptionService, DescriptionService>();
            Container.BindInRequestScope<IAbout_UsService, About_UsService>();
            Container.BindInRequestScope<ICountService, CountService>();
            Container.BindInRequestScope<ILecturerService, LecturerService>();
            Container.BindInRequestScope<IStudentService, StudentService>();
            Container.BindInRequestScope<IVideoService, VideoService>();
            Container.BindInRequestScope<IStickyService, StickyService>();
            Container.BindInRequestScope<IContactService, ContactService>();
            Container.BindInRequestScope<IAdsService, AdsService>();
            Container.BindInRequestScope<ICategoryMenuService, CategoryMenuService>();
            Container.BindInRequestScope<ICategoryNewsService, CategoryNewsService>();
            Container.BindInRequestScope<IDetailMenuService, DetailMenuService>();
            Container.BindInRequestScope<IDetailNewsService, DetailNewsService>();
            Container.BindInRequestScope<IGraduationService, GraduationService>();
        }
    }

}
