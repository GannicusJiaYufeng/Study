using KH.BLL;
using KH.Model;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Front
{
    /// <summary>
    /// ViewCourse 的摘要说明
    /// </summary>
    public class ViewCourse : IHttpHandler
    {
        //ViewCourse.ashx?id=5
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //查询课程数据   课程下的数据
            long courseId=Convert.ToInt64(context.Request["id"]);
            //通过缓存降级数据库服务器压力
            Courses course = new CoursesBLL().GetModelByCache(courseId);//new CoursesBLL().GetModel(courseId);
            if (course==null)
            {
                FrontHelper.OutPutError("课程不存在");
            }
            var chapters = new ChaptersBLL().GetModelListByCache("CourseId=" + courseId + " order by seqno ASC");
            KHHelper.OutputRazor(context, "~/ViewCourse.cshtml", new { course = course, chapters = chapters });

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