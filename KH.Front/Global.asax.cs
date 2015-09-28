using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace KH.Front
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string requestUrl = Context.Request.Url.ToString();
            //Course1.ashx
            Match matchCourse = Regex.Match(requestUrl, @"Course(\d+)\.ashx");
            if (matchCourse.Success)
            {
                string courseId = matchCourse.Groups[1].Value;
                Context.RewritePath("ViewCourse.ashx?id=" + courseId);//重写路径
            }
            Match matchSegment = Regex.Match(requestUrl, @"Segment(\d+)\.ashx");
            if (matchSegment.Success)
            {
                string segmentId = matchSegment.Groups[1].Value;
                Context.RewritePath("ViewSegment.ashx?id=" + segmentId);
            }
            //Segment5.ashx
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}