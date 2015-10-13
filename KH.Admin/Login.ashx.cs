using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace KH.Admin
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            if (action == "index")
            {
                //检查Cookie中是否保存了用户名 密码,如果有尝试登录一哈
                //自动登录有安全性哦  我这里觉得方便就用了
                if (AdminHelper.TryAutoLogin(context))
                {
                    context.Response.Redirect("Index.ashx");
                }
                else 
                {
                    KHHelper.OutputRazor(context, "~/Login.cshtml");
                    return;
                }
            }
            else if (action == "login")
            {
                string username = context.Request["username"];
                string password = context.Request["password"];
                string validCode = context.Request["validCode"];
                string autologin = context.Request["autologin"];
                if (string.IsNullOrWhiteSpace(username))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "用户名不能有空");
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "密码不能有空");
                    return;
                }
                if (string.IsNullOrWhiteSpace(validCode))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "验证码不能有空");
                    return;
                }
                string sessionValidCode = CommonHelper.GetValidCode(context);
                if (validCode != sessionValidCode)
                {//时刻注意客户端信不得！！！！！！！！！！！！！！！！！！！！！
                    //只要客户端正常，那这里的验证码就不会用，因为浏览器接下来就会自动刷新验证码
                    CommonHelper.ResetValidCode(context);//一旦错了就重置验证码//这种是避免客户端修改htmljs等影响session的刷新
                    AjaxHelper.WriteJson(context.Response, "error", "验证码错了，少年");
                    return;
                }
                //LoginResult是我在bll中定义的一个返回结果的枚举
                LoginResult result = new AdminUsersBLL().Login(username, password);
                if (result == LoginResult.UserNameNotFound)
                {
                    AjaxHelper.WriteJson(context.Response, "error", "用户名不存在");
                    return;
                }
                else if (result == LoginResult.PasswordError)
                {
                    context.Session[ValidCode.VALIDCODE] = "";
                    AjaxHelper.WriteJson(context.Response, "error", "密码错误");
                    return;
                }
                else if (result == LoginResult.OK)
                {
                    if (autologin == "on")//记住用户名密码
                    {
                        //用户名、密码存在Cookie中，免得关了浏览器session就没有了或者过时了
                        //不能把密码明文保存  md5、DES加密算法  这里用了网上找的DES加密算法写在帮助类中
                        //因为DES还可以解密  
                        AdminHelper.Remember(context, username, password);

                        AdminUsers user = new AdminUsersBLL().GetByUserName(username);
                        AdminHelper.StoreInSession(context, user.Id, user.UserName);  //Id和Name存在Session中
                    }
                    AjaxHelper.WriteJson(context.Response, "ok", "登录成功");
                    return;
                }

                else
                {
                    throw new Exception("result未知" + result);
                }
            }
            else if (action=="logout")//退出登录
            {
                //销毁session和cookie
                context.Session.Abandon();
                AdminHelper.Forget(context);
                context.Response.Redirect("Login.ashx?action=index");

            }
            else
            {
                throw new Exception("action错误");
            }

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