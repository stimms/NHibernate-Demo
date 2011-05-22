using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Autofac;
using System.Reflection;
using NHibernate.Context;
using NHibernate;
using nhibernate_demo.Repositories;

namespace nhibernate_demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ILog log;
        public static IContainer container;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void CreateContainer()
        {
            if (container == null)
            {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly()).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces();
                //SessionFactoryProvider.BuildSessionFactory().OpenSession();
                builder.Register<ISession>(x => SessionFactoryProvider.BuildSessionFactory().OpenSession()).InstancePerLifetimeScope();
                container = builder.Build();
            }
        }

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger("nhibernatedemo");
            log.Info("Starting up");

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            CreateContainer();
            log.Info("Startup complete");
        }

        protected void Application_BeginRequest()
        {
            var session = SessionFactoryProvider.BuildSessionFactory().OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest()
        {
            CurrentSessionContext.Unbind(SessionFactoryProvider.BuildSessionFactory());
        }
    }
}