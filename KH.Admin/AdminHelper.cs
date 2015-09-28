using KH.BLL;
using KH.Model;
using KHCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Admin
{
    public class AdminHelper
    {
        private const string USERNAME = "UserName";
        private const string PASSWORD = "Password";
        private const string USERID = "USERID";
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
            if (AdminHelper.GetUserIdInSession(context) == null)
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
                    AdminHelper.StoreInSession(context, user.Id, user.UserName);  //Id和Name存在Session中
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
        /// <summary>
        /// 记录一条系统操作日志
        /// </summary>
        /// <param name="description"></param>
        public static void RecordOperationLog(string description)
        {
            long? userId = GetUserIdInSession(HttpContext.Current);
            if (userId==null)
            {
                throw new Exception("当前没有用户登录");
            }
            AdminOperationLogs log = new AdminOperationLogs();
            log.UserId = (long)userId;
            log.CreatDateTime = DateTime.Now;
            log.Description = description;
            new AdminOperationLogsBLL().Add(log);
        }
        /// <summary>
        /// 判断当前登陆用户是否具有powerName这个权限
        /// if(HasPower("新增管理用户")){...}
        /// </summary>
        /// <param name="powerName"></param>
        /// <returns></returns>
        public static bool HasPower(string powerName)
        {
            //先获得当前登录用户的Id
            //获得powerName对应的T_Powers表中Id，然后到
            //T_RolePowers中查询有哪些角色有这个权限
            //，然后到[T_AdminUserRoles]中判断当前用户是否拥有这些角色。
            long? userId = GetUserIdInSession(HttpContext.Current);
            if (userId == null)
            {
                HttpContext.Current.Response.Redirect("/Login.ashx");
                // HttpContext.Current.Response.End();
            }
            return new AdminUsersBLL().HasPower(userId.Value, powerName);
        }

        /// <summary>
        /// 判断当前登陆用户是否具有powerName这个权限。如果没有，则直接提示用户，终止请求
        /// </summary>
        /// <param name="powerName"></param>
        /// <returns></returns>
        public static void CheckPower(string powerName)
        {
            if (!AdminHelper.HasPower(powerName))
            {
                HttpContext.Current.Response.Write("当前用户没有【" + powerName + "】权限");
                HttpContext.Current.Response.End();
            }
        }
    }
}