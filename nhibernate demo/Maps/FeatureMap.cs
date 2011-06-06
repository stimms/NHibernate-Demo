using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using nhibernate_demo.Models;

namespace nhibernate_demo.Maps
{
    public class FeatureMap : ClassMap<Feature>
    {
        public FeatureMap()
        {
            Id(x => x.ID);

            Map(x => x.Name);

            HasManyToMany(x => x.Grains);
        }
    }
}