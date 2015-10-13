using KHRazor;
using KH.BLL;
using KH.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using KHCommons;

namespace KH.Front
{
    public class FrontHelper
    {
        public static void OutPutError(string msg)
        {
            KHHelper.OutputRazor(HttpContext.Current, "~/Error.cshtml", msg);
        }

        public static void OutputMsg(string msg)
        {
            KHHelper.OutputRazor(HttpContext.Current, "~/Msg.cshtml", msg);
        }


        public static List<Segments> GetSegment(long chapterId)
        {
            return new SegmentsBLL().GetModelListByCache("ChapterId=" + chapterId + " order by seqno ASC");
        }
        public static void SendEmail(string toEmail, string subject, string body)
        {
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            string smtpFrom = ConfigurationManager.AppSettings["SmtpFrom"];
            string smtpUserName = ConfigurationManager.AppSettings["SmtpUserName"];
            string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

            MailMessage mailObj = new MailMessage();
            mailObj.IsBodyHtml = true;   //邮件正文是否是html格式
            mailObj.From = new MailAddress(smtpFrom); //发送人邮箱地址   一定要启用smtp服务
            mailObj.To.Add(toEmail);   //收件人邮箱地址
            mailObj.Subject = subject;    //主题
            mailObj.Body = body;    //正文
            SmtpClient smtp = new SmtpClient();//通过.Net内置的SmtpClient类和邮件服务器进行通讯，发送邮件。
            //是和发邮件方的smtp通讯，由发邮件方的邮件服务器和收邮件方的邮件服务器通讯进行邮件的转接。
            smtp.Host = smtpServer;         //smtp服务器名称
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(smtpUserName, smtpPassword);  //发送人的登录名和密码
            smtp.Send(mailObj);
        }
        /// <summary>
        /// 设置当前登陆用户名
        /// </summary>
        /// <param name="context"></param>
        /// <param name="username"></param>
        public static void SetCurrentUserName(HttpContext context, string username)
        {
            context.Session[USERNAME] = username;
        }

        /// <summary>
        /// 获取当前登录用户名
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentUserName(HttpContext context)
        {
            return (string)context.Session[USERNAME];
        }
        public const string USERNAME = "FRONTUSERNAME";
        public const string PASSWORD = "FRONTPASSWORD";
        public const string USERID = "FRONTUSERID";
        /// <summary>
        /// 把登录用户名和id存到Sessoin
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        public static void StoreInSession(HttpContext context,
            long userId, string username)
        {
            context.Session[USERID] = userId;
            context.Session[USERNAME] = username;
        }
        /// <summary>
        /// Session中取到Id
        /// </summary>
        /// <returns></returns>
        public static long? GetUserIdInSession(HttpContext context)
        {
            return (long?)context.Session[USERID];
        }
        /// <summary>
        /// Session中取到Name
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetUserNameInSession(HttpContext context)
        {
            return (string)context.Session[USERNAME];
        }

        /// <summary>
        /// 保存用户名密码到Cookie中
        /// </summary>
        /// <param name="context"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Remember(HttpContext context, string username, string password)
        {
            //用户名、密码存在Cookie中，免得关了浏览器session就没有了或者过时了
            //不能把密码明文保存  md5、DES加密算法  这里用了网上找的DES加密算法
            context.Response.SetCookie(new HttpCookie("USERNAME", username) { Expires = DateTime.Now.AddDays(200) });
            context.Response.SetCookie(new HttpCookie("PASSWORD", CommonHelper.DesEncypt(password)) { Expires = DateTime.Now.AddDays(200) });
        }
        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        /// <param name="context"></param>
        public static void CheckAccess(HttpContext context)
        {
            if (FrontHelper.GetUserIdInSession(context) == null)
            {
                context.Response.Redirect("/Login.ashx?action=index", true);//重定向并终止当前页请求
                return;
            }
        }
        /// <summary>
        /// 忘记Cookie中存储的用户名，密码
        /// </summary>
        /// <param name="context"></param>
        public static void Forget(HttpContext context)
        {
            context.Response.SetCookie(new HttpCookie("USERNAME", "") { Expires = DateTime.Now.AddDays(-1) });
            context.Response.SetCookie(new HttpCookie("PASSWORD", "") { Expires = DateTime.Now.AddDays(-1) });
            //原理：设置过期时间来删除cookie
        }
        /// <summary>
        /// 尝试登录，因为可能用户在另一台电脑换了密码，然后再来这台电脑登录
        /// </summary>
        /// <returns>是否登录成功</returns>
        public static bool TryAutoLogin(HttpContext context)
        {
            HttpCookie cookieUserName = context.Request.Cookies[USERNAME];
            var cookiePassword = context.Request.Cookies[PASSWORD];
            if (cookieUserName != null && cookiePassword != null)
            {
                string username = cookieUserName.Value;
                string passwordDES = cookiePassword.Value;
                string password = CommonHelper.DesDecrypt(passwordDES);//DES解密
                AdminUsersBLL bll = new AdminUsersBLL();
                //return  bll.Login(username, password)==LoginResult.OK;
                LoginResult loginResult = bll.Login(username, password);
                if (loginResult == LoginResult.OK)
                {
                    AdminUsers user = new AdminUsersBLL().GetByUserName(username);
                    FrontHelper.StoreInSession(context, user.Id, user.UserName);  //Id和Name存在Session中
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}