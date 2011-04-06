using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nhibernate_demo.Models
{
    public class ChocolateBar
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Chocolatier Chocolatier {get;set;}
        public virtual IList<Feature> Features { get; set; }
    }
}