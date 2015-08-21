using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;
using System.Security.Cryptography;

namespace RpCater.Bll
{
    public class UserInfoBll
    {
        UserInfoDAL userDal = new UserInfoDAL();
        //MD5加密
        private static string GetPwdMD5(string pwd)
        {
            string s = "";
            //获取字符串byte字节数组
            byte[] byteValues = System.Text.Encoding.UTF8.GetBytes(pwd);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //计算byte字数组产生新的byte字节数组
            byte[] byteDatas = md5.ComputeHash(byteValues);
            for (int i = 0; i < byteDatas.Length; i++)
            {
                s += byteDatas[i].ToString("X2");//X2表示16进制
            }
            return s;
        }

        /// <summary>
        /// 根据登录名查询数据库
        /// </summary>
        /// <param name>登录名，密码</param>
        /// <returns>状态信息</returns>
        public LoginStatus GetUserInfoByLoginName(string loginName,string pwd)
        {
            pwd = GetPwdMD5(pwd);//新的MD5值
            UserInfo user = userDal.GetUserInfoByLoginName(loginName);
            if (user == null)
            {
                return LoginStatus.LoginNameNotFound;
            }
            if (user.Pwd!=pwd)
            {
                return LoginStatus.PasswordError;
            }
            return LoginStatus.OK;
        }
    }
}
