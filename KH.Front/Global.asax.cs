using KHCommons;
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

        public override void Init()
        {
            base.Init();
            //必须到Init中来监听
            //每个需要Session页面启动都会执行AcquireRequestState事件
            //AcquireRequestState事件执行的时候Session已经准备好了
            //客户端每次访问实现了IRequiresSessionState的接口都会触发AcquireRequestState事件
            this.AcquireRequestState += Global_AcquireRequestState;
        }
        void Global_AcquireRequestState(object sender, EventArgs e)
        {
            if (Session == null)
            {
                return;
            }
            string username = FrontHelper.GetCurrentUserName(Context);
            if (username == null)
            {
                return;
            }
            //同一个用户名只能在一个Session中登陆
            using (var client = RedisManager.ClientManager.GetClient())
            {
                string redisSessionId = client.Get<string>(FrontHelper.USERNAME + username);
                //如果Redis中，当前用户名对应的SessionId不能与当前请求的SessionID的值
                //则表示“朕被篡位了！”，自动退出(因为asp.net中没法销毁其他人的Session，因此不能在登陆的时候销毁其他的Session，所以改成自杀)
                if (redisSessionId != null && redisSessionId != Session.SessionID)
                {
                    Session.Clear();//清除数据
                    Session.Abandon();//销毁Session
                }
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //不能在Application_BeginRequest中操作session  因为这时候session还没准备好，session还是null
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