using System;
using System.Linq;
using nhibernate_demo.Models;

namespace nhibernate_demo.Repositories
{
    public interface IChocolatierRepository
    {
        IQueryable<Chocolatier> GetChocolatiers();
        Chocolatier GetByID(int id);
        void Delete(int id);
        void Save(Chocolatier chocolatier);
    }
}
