using System;
using System.Linq;
using nhibernate_demo.Models;

namespace nhibernate_demo.Repositories
{
    public interface IChocolateBarRepository
    {
        IQueryable<ChocolateBar> GetChocolateBars();
        ChocolateBar GetByID(int id);
        void Save(ChocolateBar chocolateBar, int chocolatierID);
        void Delete(int chocolateBarID);
    }
}
