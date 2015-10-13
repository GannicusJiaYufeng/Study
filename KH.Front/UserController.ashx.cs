using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace KH.Front
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class UserController : BaseHandler
    {
        private const string ACTIVECODE_PREFIX = "UserActiveCode.";
        /// <summary>
        /// 浏览器询问服务器：我登陆了吗？用户名是什么？
        /// </summary>
        /// <param name="context"></param>
        public void isLogin(HttpContext context)
        {
            string username = FrontHelper.GetCurrentUserName(context);
            if (string.IsNullOrEmpty(username))
            {
                AjaxHelper.WriteJson(context.Response, "no", "");
            }
            else
            {
                AjaxHelper.WriteJson(context.Response, "yes", username);
            }
        }
        public void login(HttpContext context)
        {

            string username = context.Request["username"];
            string password = context.Request["password"];
            string validCode = context.Request["validCode"];
            string autologin = context.Request["autologin"];
            if (string.IsNullOrWhiteSpace(username))
            {
                AjaxHelper.WriteJson(context.Response, "error", "用户名不能为空"); return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                AjaxHelper.WriteJson(context.Response, "error", "密码不能有空"); return;
            }
            if (string.IsNullOrWhiteSpace(validCode))
            {
                AjaxHelper.WriteJson(context.Response, "error", "验证码不能有空"); return;
            }
            string sessionValidCode = context.Session[CommonHelper.VALIDCODE].ToString();
            if (validCode != sessionValidCode)
            {//时刻注意客户端信不得！！！！！！！！！！！！！！！！！！！！！
                //只要客户端正常，那这里的验证码就不会用，因为浏览器接下来就会自动刷新验证码
                CommonHelper.ResetValidCode(context);//一旦错了就重置验证码//这种是避免客户端修改htmljs等影响session的刷新
                AjaxHelper.WriteJson(context.Response, "error", "验证码错了，少年"); return;
            }
            //UserLoginResult是我在bll中定义的一个返回结果的枚举
            KH.BLL.UsersBLL.UserLoginResult result = new UsersBLL().Login(username, password);
            if (result == KH.BLL.UsersBLL.UserLoginResult.UserNameNotFound)
            {
                AjaxHelper.WriteJson(context.Response, "error", "用户名不存在"); return;
            }
            else if (result == KH.BLL.UsersBLL.UserLoginResult.PasswordError)
            {
                context.Session[CommonHelper.VALIDCODE] = "";
                AjaxHelper.WriteJson(context.Response, "error", "密码错误"); return;
            }
            else if (result == KH.BLL.UsersBLL.UserLoginResult.OK)
            {
                FrontHelper.SetCurrentUserName(context, username);//登录成功后 设置session中当前登录用户名
                //登录时把用户名和SessionId对应关系存入Redis
                using (var client=RedisManager.ClientManager.GetClient())
                {
                    client.Set<string>(FrontHelper.USERNAME + username, context.Session.SessionID);
                }
                
                AjaxHelper.WriteJson(context.Response, "ok", "");
            }
            else
            {
                AjaxHelper.WriteJson(context.Response, "error", "未知的登陆结果");
            }
        }
        public void registerSubmit(HttpContext context)
        {
            string username = context.Request["username"];
            string password = context.Request["password"];
            string email = context.Request["email"];
            string validCode = context.Request["validCode"];
            if (string.IsNullOrWhiteSpace(username))
            {
                AjaxHelper.WriteJson(context.Response, "error", "用户名不能有空"); return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                AjaxHelper.WriteJson(context.Response, "error", "密码不能有空"); return;
            }
            if (string.IsNullOrWhiteSpace(validCode))
            {
                AjaxHelper.WriteJson(context.Response, "error", "验证码不能有空"); return;
            }
            if (string.IsNullOrEmpty(email))
            {
                AjaxHelper.WriteJson(context.Response, "error", "邮箱不能有空"); return;
            }
            if (!Regex.IsMatch(email, "^[0-9a-zA-Z_.-]+@[0-9a-zA-Z_.-]+[.]([a-zA-Z]+){1,2}$"))
            {
                AjaxHelper.WriteJson(context.Response, "error", "邮箱地址不正确"); return;
            }
            //if (new UsersBLL().IsHaveThisEmail(email))
            //{
            //    AjaxHelper.WriteJson(context.Response, "error", "该邮箱已经被注册过了"); return;
            //}
            if (validCode != CommonHelper.GetValidCode(context))
            {
                AjaxHelper.WriteJson(context.Response, "error", "验证码错误"); CommonHelper.ResetValidCode(context); return;
            }
            UsersBLL userBll = new UsersBLL();
            if (!userBll.CheckUserNameOnReg(username))        //检查用户名是否可用
            {
                AjaxHelper.WriteJson(context.Response, "error", "此用户名不可用"); return;
            }
            long userId = userBll.AddNewUser(username, password, email);
            Random rand = new Random();
            string activeCode = rand.Next(10000, 99999).ToString();//生成激活码
            //这里用redis   存储键值对的nosql数据库代替以前写的插入激活码表
            using (var client = RedisManager.ClientManager.GetClient())
            {
                client.Set<string>(ACTIVECODE_PREFIX + username, activeCode, DateTime.Now.AddMinutes(30));
            }



            /*UserActiveCodes userActiveCode = new UserActiveCodes();
            userActiveCode.UserName = username;
            userActiveCode.ActiveCode = activeCode;
            new UserActiveCodesBLL().Add(userActiveCode);//插入激活码表*/

            //发送邮件  UrlEncode可能用户名有特殊字符，这里处理一下
            string activeUrl = "http://localhost:3847/UserController.ashx?action=active&username=" +
                context.Server.UrlEncode(username) + "&activeCode=" + activeCode;
            string emailBody = "尊敬的" + username + "您好，请点击下面的链接激活您的账户(有效期三十分钟)"
                + "<a href='" + activeUrl + "'>点击此链接激活您的账号</a>，如果链接打不开，则把下面的地址复制到浏览器中进行激活：" + activeUrl;
            FrontHelper.SendEmail(email, "请激活您的匡衡教育账号", emailBody);

            //发垃圾邮件  有数量限制   不可能的
            //在正式运行的项目中，无法使用163、qq等这种免费邮箱发送大量的邮件。
            //Edm专用服务器，掏钱就ok。
            //白名单联盟
            //SendCloud、Comm100、yiye
            AjaxHelper.WriteJson(context.Response, "ok", "");
        }
        public void active(HttpContext context)
        {
            string username = context.Request["username"];
            string activeCode = context.Request["activeCode"];
            /*UserActiveCodesBLL activeCodeBll = new UserActiveCodesBLL();
            UserActiveCodes activeCodeModel = activeCodeBll.GetByUserName(username);
            if (activeCodeModel == null)
            {
                FrontHelper.OutPutError("username不存在");return;
            }
            if (activeCode != activeCodeModel.ActiveCode)
            {
                FrontHelper.OutPutError("激活码不正确");return;
            }
             */
            using (var client = RedisManager.ClientManager.GetClient())
            {
                string activeCodInRedis = client.Get<string>(ACTIVECODE_PREFIX + username);
                if (activeCodInRedis == null || activeCode != activeCodInRedis)
                {
                    FrontHelper.OutPutError("激活码不正确");
                    return;
                }
            }

            new UsersBLL().Active(username);
            if ((new UsersBLL().GetByUserName(username)).IsActive == true)
            {
                FrontHelper.OutPutError("请勿重复激活"); return;
            }
            FrontHelper.OutputMsg("恭喜您，激活成功");
        }
        public void createValideCode(HttpContext context)
        {
            CommonHelper.createValidCode(context);
        }
        public void checkUserName(HttpContext context)
        {
            string username = context.Request["username"];
            if (new UsersBLL().CheckUserNameOnReg(username))
            {
                AjaxHelper.WriteJson(context.Response, "ok", "");
            }
            else
            {
                AjaxHelper.WriteJson(context.Response, "error", "此用户名不可用");
            }
        }
    }
}