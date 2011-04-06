using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using nhibernate_demo.Models;

namespace nhibernate_demo.Maps
{
    public class ChocolatierMap : ClassMap<Chocolatier>
    {
        public ChocolatierMap()
        {
            Id(x => x.ID);

            Map(x => x.Name);
        }
    }
}