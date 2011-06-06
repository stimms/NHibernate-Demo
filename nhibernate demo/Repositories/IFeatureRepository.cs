using System;
namespace nhibernate_demo.Repositories
{
    interface IFeatureRepository
    {
        void Save(nhibernate_demo.Models.Feature feature);
    }
}
