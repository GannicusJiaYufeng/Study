using KHCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace KH.Front
{
    /// <summary>
    /// ValidCode 的摘要说明
    /// </summary>
    public class ValidCode : IHttpHandler, IRequiresSessionState
    {

        public const string VALIDCODE = "VALIDCODE";

        public void ProcessRequest(HttpContext context)
        {
            CommonHelper.createValidCode(context);
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