using System;
using System.Linq;
using nhibernate_demo.Models;

namespace nhibernate_demo.Repositories
{
    public interface IGrainRepository
    {
        IQueryable<Grain> GetGrains();
        Grain GetByID(int id);
        void Save(Grain grain, int farmerID);
        void Delete(int grainID);
    }
}
