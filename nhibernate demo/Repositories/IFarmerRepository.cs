using System;
using System.Linq;
using nhibernate_demo.Models;

namespace nhibernate_demo.Repositories
{
    public interface IFarmerRepository
    {
        IQueryable<Farmer> GetFarmers();
        Farmer GetByID(int id);
        void Delete(int id);
        void Save(Farmer farmer);
    }
}
