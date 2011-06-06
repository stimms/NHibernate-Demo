using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace nhibernate_demo.JsonSerialization
{
    public class NewtonsoftJsonActionResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            var serializer = new JsonSerializer
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new NHibernateContractResolver()
            };
            StringWriter stringWriter = new StringWriter();
            StreamWriter streamWriter = new StreamWriter(response.OutputStream);
            JsonWriter jsonWriter = new Newtonsoft.Json.JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, Data);
            response.Write(stringWriter.ToString());
            //streamWriter.Write(stringWriter.ToString());
        }
    }
}