using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nhibernate_demo.Models;
using NHibernate;
using NHibernate.Linq;

namespace nhibernate_demo.Repositories
{
    public class ChocolatierRepository : BaseRepository, IChocolatierRepository
    {
        public IQueryable<Chocolatier> GetChocolatiers()
        {
           return _session.Query<Chocolatier>();
        }

        public Chocolatier GetByID(int id)
        {
            return _session.Load<Chocolatier>(id);
        }

        public void Delete(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(_session.Load<Chocolatier>(id));
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                    throw ex;
                }
            }
        }

        public void Save(Chocolatier chocolatier)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(chocolatier);
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