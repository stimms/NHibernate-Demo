using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using nhibernate_demo.Models;

namespace nhibernate_demo.Maps
{
    public class ChocolateBarMap : ClassMap<ChocolateBar>
    {
        public ChocolateBarMap()
        {
            Id(x => x.ID);

            Map(x => x.Name);

            References(x => x.Chocolatier).Column("ChocolatierID");

            HasMany(x => x.Features);
        }
    }
}