using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(FacultyV3.Web.App_Start.Startup))]
namespace FacultyV3.Web.App_Start
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Core;
    using Core.Data.Context;
    using Core.Ioc;
    using Core.Migrations;
    using Unity;
    using System.Web.Optimization;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Start unity
            UnityHelper.InitialiseUnityContainer();

            // Make DB update to latest migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

            // Set the rest of the Ioc
            UnityHelper.BuildUnityContainer();

            // Grab the container as we will need to use it
            var unityContainer = UnityHelper.Container;

            // Set Hangfire to use SQL Server and the connection string
            //GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server=.\SQLExpress;database=OriginV;Trusted_Connection=True;");
            GlobalConfiguration.Configuration.UseSqlServerStorage(FacultyV3Confirguration.Instance.OriginContext);

            // Make hangfire use unity container
            GlobalConfiguration.Configuration.UseUnityActivator(unityContainer);

            // Add Hangfire
            // TODO - Do I need this dashboard?
            //app.UseHangfireDashboard();
            app.UseHangfireServer();

            // Get services needed
            var DataContext = unityContainer.Resolve<DataContext>();

            // Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

}