using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Context;

namespace nhibernate_demo.Repositories
{
    public class BaseRepository
    {
        protected ISession _session;
        public BaseRepository(ISession session)
        {
            _session = session;
        }


    }
}