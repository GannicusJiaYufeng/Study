using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace KH.Admin
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            AdminHelper.CheckAccess(context);//检查是否登录，是否有权限
            string username=AdminHelper.GetUserNameInSession(context);
            string html = KHHelper.ParseRazor(context, "~/Index.cshtml",new {UserName=username});
            context.Response.Write(html);

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