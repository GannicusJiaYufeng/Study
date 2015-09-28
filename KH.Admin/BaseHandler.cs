using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace KH.Admin
{
    public class BaseHandler:IHttpHandler,IRequiresSessionState
    {

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
        public void ProcessRequest(HttpContext context)
        {

            AdminHelper.CheckAccess(context);//检查是否登录
            //action的名字要和处理这个action的方法名一样，并且要有如下参数(HttpContext context)
            //action=list  就要有方法： public void list(HttpContext context)
            string action = context.Request["action"];//约定必须有传参数action表示要执行什么方法
            Type ctrType = this.GetType();
            //这里获得的是 CourseController的类型，因为用户是对 CourseController.ashx发出请求的。
            // CourseController.ashx.cs是实现了这个类的，是他的子类
            MethodInfo methodAction = ctrType.GetMethod(action);//获取子类方法
            if (methodAction==null)
            {
                throw new Exception("action不存在");
            }
            methodAction.Invoke(this, new object[] { context });  //用指定参数调用当前实例所表示的方法
        }
    }
}