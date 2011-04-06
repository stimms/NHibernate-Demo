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
                                   .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ChocolateBarMap>())
                                   .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                                   .ExposeConfiguration(UpdateSchema)
                                   .BuildSessionFactory();
                    
                    
            }
            return _session;
        }

        private static void UpdateSchema(NHibernate.Cfg.Configuration conf)
        {
            //new SchemaExport(conf).Execute(true, true, false);
            new SchemaUpdate(conf).Execute(true, true);
        }
    }
}