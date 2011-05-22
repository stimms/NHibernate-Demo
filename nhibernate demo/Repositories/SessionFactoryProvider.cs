using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using NHibernate.Tool.hbm2ddl;
using nhibernate_demo.Maps;

namespace nhibernate_demo.Repositories
{
    public class SessionFactoryProvider
    {
        private static ISessionFactory _session;

        public static ISessionFactory BuildSessionFactory()
        {
            if (_session == null)
            {
                _session = Fluently.Configure()
                                   .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ChocolateBarMap>().Conventions.AddFromAssemblyOf<CascadeConvention>())
                                   .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                                   .ExposeConfiguration(UpdateSchema)
                                   .CurrentSessionContext("web")
                                   .BuildSessionFactory();
                    
                    
            }
            return _session;
        }

        private static void UpdateSchema(NHibernate.Cfg.Configuration conf)
        {
            bool cleanDatabaseOnLaunch = false;
            if (ConfigurationManager.AppSettings["CleanDatabaseOnLaunch"] !=  null 
             && bool.TryParse(ConfigurationManager.AppSettings["CleanDatabaseOnLaunch"], out cleanDatabaseOnLaunch) 
             && cleanDatabaseOnLaunch)
            {
                new SchemaExport(conf).Execute(true, true, false);
            }
            
            new SchemaUpdate(conf).Execute(true, true);
        }
    }
}