using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace nhibernate_demo.Repositories
{
    public class nhibernateRepo1 : BaseRepository
    {
        public nhibernateRepo1(ISession session) : base(session) { }
    }
}