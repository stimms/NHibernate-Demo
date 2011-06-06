using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace nhibernate_demo.JsonSerialization
{
    public static class IEnumerableExtensions
    {
        public static string ToJson<T>(this IEnumerable<T> toSerialize)
        {
            var serializer = new JsonSerializer
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new NHibernateContractResolver()
            };
            StringWriter stringWriter = new StringWriter();
            JsonWriter jsonWriter = new Newtonsoft.Json.JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, toSerialize);
            return stringWriter.ToString();
        }
    }
}