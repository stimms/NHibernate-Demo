using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace nhibernate_demo.Repositories
{
    public class CascadeConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }
    }
}