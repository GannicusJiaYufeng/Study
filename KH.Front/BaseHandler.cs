using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace KH.Front
{
    public class BaseHandler:IHttpHandler,IRequiresSessionState
    {


        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            //我约定，参数中都要有一个action参数，表示要执行什么方法
            //action的名字要和处理这个action的方法名一样，并且有如下参数(HttpContext context)
            //action=list，public void list(HttpContext context)
            string action = context.Request["action"];//action=...

            //额外任务：在Power表中增加ControllerName、Action两个列

            //如下要求（约定）：必须有一个请求参数action，处理这个action的方法名字必须和action一致
            //参数必须是(HttpContext context)
            Type ctrlType = this.GetType();
            MethodInfo methodAction = ctrlType.GetMethod(action);//拿到的就是比如list(HttpContext context)方法
            if (methodAction == null)
            {
                throw new Exception("action不存在");
            }
            methodAction.Invoke(this, new object[] { context });
        }
    }
}