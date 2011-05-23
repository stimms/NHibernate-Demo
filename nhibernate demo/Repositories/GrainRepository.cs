using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nhibernate_demo.Models;
using NHibernate.Linq;
using NHibernate;

namespace nhibernate_demo.Repositories
{
    public class GrainRepository : BaseRepository, IGrainRepository
    {

        public GrainRepository(ISession session) : base(session) { }

        public IQueryable<Grain> GetGrains()
        {
            return _session.Query<Grain>();

        }

        public Grain GetByID(int id)
        {
            return _session.Load<Grain>(id);
        }

        public void Save(Grain grain, int farmerID)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    grain.Farmer = _session.Load<Farmer>(farmerID);
                    _session.Merge(grain);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }

            }
        }

        public void Delete(int grainID)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(_session.Load<Grain>(grainID));
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }

            }
        }


    }
}