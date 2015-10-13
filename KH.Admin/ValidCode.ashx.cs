using KHCommons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace KH.Admin
{
    /// <summary>
    /// 验证码
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