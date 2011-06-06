using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using NHibernate.Proxy;

namespace nhibernate_demo.JsonSerialization
{
    public class NHibernateContractResolver:DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            if (typeof(INHibernateProxy).IsAssignableFrom(objectType))
            {
                return base.GetSerializableMembers(objectType.BaseType);
            }
            else
            {
                return base.GetSerializableMembers(objectType);
            }
        }

    }
}