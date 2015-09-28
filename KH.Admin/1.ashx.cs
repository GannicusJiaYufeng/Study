using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Admin
{
    /// <summary>
    /// _1 的摘要说明
    /// </summary>
    public class _1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}