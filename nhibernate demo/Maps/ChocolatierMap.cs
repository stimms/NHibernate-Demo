using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using nhibernate_demo.Models;

namespace nhibernate_demo.Maps
{
    public class FarmerMap : ClassMap<Farmer>
    {
        public FarmerMap()
        {
            Id(x => x.ID);

            Map(x => x.Name);
        }
    }
}