using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RpCater.Model;

namespace RpCater.DAL
{
    public class UserInfoDAL
    {
        /// <summary>
        /// 根据登录名查询数据库
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns>登录用户对象</returns>
        public UserInfo GetUserInfoByLoginName(string loginName)
        {
            string sql = "select *from UserInfo where delFlag=0 and LoginUserName=@LoginUserName";

            DataTable dt = SqlHelper.ExecuteQuery(sql, new SqlParameter("@LoginUserName", loginName));
            UserInfo userInfo = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    userInfo = RowToUserInfoByDataRow(dr);
                }      
            }
            return userInfo;
        }

        //关系转对象
        private UserInfo RowToUserInfoByDataRow(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.Pwd = dr["Pwd"].ToString();
            user.UserId = Convert.ToInt32(dr["UserId"]);
            user.UserName = dr["UserName"].ToString();
            return user;
        }
    }
}
