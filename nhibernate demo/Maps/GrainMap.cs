using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using nhibernate_demo.Models;

namespace nhibernate_demo.Maps
{
    public class GrainMap : ClassMap<Grain>
    {
        public GrainMap()
        {
            Id(x => x.ID);

            Map(x => x.Name);

            References(x => x.Farmer).Column("FarmerID");

            HasManyToMany(x => x.Features);
        }
    }
}