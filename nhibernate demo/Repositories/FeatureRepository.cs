using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace nhibernate_demo.Repositories
{
    public class FeatureRepository:BaseRepository
    {
        public FeatureRepository(ISession session) : base(session) { }
    }
}