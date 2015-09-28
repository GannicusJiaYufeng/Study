using KH.BLL;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Front
{
    /// <summary>
    /// ViewSegment 的摘要说明
    /// </summary>
    public class ViewSegment : IHttpHandler
    {
        //查看课程不能做静态化。因为有业务逻辑，没有购买就不能查看
        //新闻是谁都可以看，没有业务逻辑，就可以用页面静态化
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            long id = Convert.ToInt64(context.Request["id"]);
            var segment = new SegmentsBLL().GetModelByCache(id);
            if (segment == null) 
            {
                KHHelper.OutputRazor(context, "~/Error.cshtml", "segment不存在");
                return;
            }
            KHHelper.OutputRazor(context, "~/ViewSegment.cshtml", segment);
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