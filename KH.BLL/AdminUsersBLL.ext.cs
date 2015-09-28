using KH.Model;
using KHCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class AdminUsersBLL
    {
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public AdminUsers GetByUserName(string username)
        {
            return dal.GetByUserName(username);
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsUserNameExists(string username)
        {
            return GetByUserName(username)!=null;
        }
        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">原始密码：123456</param>
        public void AddUser(string username,string password)
        {
            //MD5处理放到BLL中，UI层最好只获取用户输入，合法性检测，输出
            AdminUsers user = new AdminUsers();
            user.UserName = username;
            user.Password = CommonHelper.CalcMD5(password);
            user.IsEnabled = true;
            Add(user); //Add这个是代码生成器的方法
        }
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id"></param>
        public void Disable(long id)
        {
            AdminUsers user = GetModel(id);
            user.IsEnabled = false;
            Update(user);
        }
        /// <summary>
        /// 登录 即：判断用户名密码是否一致
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public  LoginResult Login(string username,string password)
        {
            AdminUsers user = GetByUserName(username);
            if (user==null)
            {
                return LoginResult.UserNameNotFound;
            }
            else if (user.Password!=CommonHelper.CalcMD5(password))
            {
                return LoginResult.PasswordError;
            }
            else
            {
                return LoginResult.OK;
            }
        }
        public bool HasPower(long userId, string powerName)
        {
            return dal.HasPower(userId, powerName);
        }
    }
    /// <summary>
    /// 登陆结果的枚举 。其实写到UI成也可以，还简单些，只是养成好习惯，顺便我复习一下枚举
    /// </summary>
    public enum LoginResult{OK,UserNameNotFound,PasswordError};
}
