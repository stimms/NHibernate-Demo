using System;
using System.Collections.Generic;

namespace nhibernate_demo.Models
{
    public class Grain
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Farmer Farmer {get;set;}
        public virtual IList<Feature> Features { get; set; }
    }
}