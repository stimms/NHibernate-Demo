using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nhibernate_demo.Models;
using NHibernate.Linq;

namespace nhibernate_demo.Repositories
{
    public class ChocolateBarRepository : BaseRepository, IChocolateBarRepository
    {
        public IQueryable<ChocolateBar> GetChocolateBars()
        {
            return _session.Query<ChocolateBar>();
        }

        public ChocolateBar GetByID(int id)
        {
            return _session.Load<ChocolateBar>(id);
        }
            

        public void Save(ChocolateBar chocolateBar, int chocolatierID)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    chocolateBar.Chocolatier = _session.Load<Chocolatier>(chocolatierID);
                    _session.SaveOrUpdate(chocolateBar);
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

        public void Delete(int chocolateBarID)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(_session.Load<ChocolateBar>(chocolateBarID));
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