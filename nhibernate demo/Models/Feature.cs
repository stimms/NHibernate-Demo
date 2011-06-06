using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhibernate_demo.Models
{
    public class Feature
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Grain> Grains { get; set; }
    }
}
