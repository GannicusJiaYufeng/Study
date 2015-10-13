using KH.Model;
using KHCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class UsersBLL
    {

        // public bool Login(string username, string password)
        //{
        //项目任务：验证登录
        //dal.GetByUserName(username);
        //}
        public Users GetByUserName(string username)
        {
            return dal.GetByUserName(username);
        }
        public void Active(string username)
        {
            Users user = new UsersBLL().GetByUserName(username);
            if (user == null)
            {
                throw new Exception("没有根据用户名" + username + "找到用户信息");
            }
            user.IsActive = true;
            Update(user);
        }
        //添加用户
        public long AddNewUser(string username, string password, string email)
        {
            Users user = new Users();
            user.UserName = username;
            user.Password = CommonHelper.CalcMD5(password);
            user.Email = email;
            user.RegDateTime = DateTime.Now;
            user.IsActive = false;

            return Add(user);
        }
        /// <summary>
        /// 注册时判断用户名是否可用
        /// </summary>
        /// <param name="username"></param>
        /// <returns>返回true表示可用，返回false表示不可用</returns>
        public bool CheckUserNameOnReg(string username)
        {
            Users u = GetByUserName(username);
            return u == null;
        }
        public bool IsHaveThisEmail(string email)
        {
            return dal.IsHaveThisEmail(email) > 0;
        }
        /// <summary>
        /// 登录 即：判断用户名密码是否一致
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserLoginResult Login(string username, string password)
        {
            Users user = GetByUserName(username);
            if (user == null)
            {
                return UserLoginResult.UserNameNotFound;
            }
            else if (user.Password != CommonHelper.CalcMD5(password))
            {
                return UserLoginResult.PasswordError;
            }
            else
            {
                return UserLoginResult.OK;
            }
        } 
        //登录结果
        public enum UserLoginResult { OK, UserNameNotFound, PasswordError,UserNameDisabled };
    }

}
